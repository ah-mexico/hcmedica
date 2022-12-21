Imports System.IO
Imports System.Collections
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.HistoriaBasica
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports System.Collections.Generic

Public Class ctlCriterioIngreso
    Private Shared _Instancia As ctlCriterioIngreso
    Private objGeneral As Generales
    Private objPaciente As Paciente
    Private objConexion As Conexion
    Private objEvolucion As Evolucion
    Private objDescrQx As DescripcionQuirurgica
    Private objQx As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAODescripcionQX
    Private objQxManejaDatos As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAODescripcionQXManejoDeDatos
    Private strCirujanoInvitado As String = ""
    Private strClasifiDiagn As String = ""
    Private objHistoriaBasica As DatosHistoriaBasica
    Private iDemenciaSeveridad As Integer = 0
    Private iDemenciaProgresion As Integer = 0
    Private iDemenciaUsoRecursos As Integer = 0
    Private iParkinson As Integer = 0
    Private iMotoNeurona As Integer = 0
    Private iEsclerosis As Integer = 0
    Private iCardiaca As Integer = 0
    Private iCerebroVascular As Integer = 0
    Private iPulmonar As Integer = 0

    Private iFragilidadNutricional As Integer = 0
    Private iFragilidadFuncional As Integer = 0
    Private iFragilidadGlobal As Integer = 0
    Public Shared CriterioIngreso As Integer = 0
    ''WACHV, VBLES PARA CONTROLAR CADA ESTADO
    Public Shared iCriterio As Integer = 0
    Public Shared bMostrar As Boolean = False

    Public Enum Criterio
        Ninguno = 0
        Enfermedad_Oncologica = 1
        VIHSIDA = 2
        Demencia = 3
        Parkinson = 4
        Enfermedad_de_Motoneurona = 5
        Esclerosis_Multiple = 6
        Enfermedad_Cardiaca_Cronica = 7
        Evento_Cerebrovalsular = 8
        Enfermedad_Pulmonar_Cronica = 9
        Enfermedad_Hepatica_Cronica_Grave = 10
        Enfermedad_Renal_Cronica_Grave = 11
        Fragilidad_Severa = 12
    End Enum

#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As ctlCriterioIngreso
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlCriterioIngreso
            End If
            Return _Instancia
        End Get
    End Property
#End Region

#Region "Events"

    'Private Sub ctlCriterioIngreso_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

    'End Sub

    'Private Sub ctlCriterioIngreso_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

    'End Sub

    'Private Sub ctlCriterioIngreso_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
    '    Try
    '        If Me.Visible Then
    '            loadCriterioIngreso(New CriterioIngreso)
    '            objGeneral = Generales.Instancia
    '            objPaciente = Paciente.Instancia

    '            If CriterioIngreso <> 0 Then
    '                MostrarCriterio()
    '            Else
    '                MessageBox.Show("El diagnóstico seleccionado no corresponde a los criterios esperados. ", "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
    '            End If
    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub


    Private Sub ctlCriterioIngreso_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Me.Visible Then

                objGeneral = Generales.Instancia
                objPaciente = Paciente.Instancia

                fnRadioButtonSinMarcar(CriterioIngreso) ''29sept2017,WACHV, limpia controles x defecto radio button sin seleccionar
                If CriterioIngreso <> 0 Then
                    iCriterio = CriterioIngreso '19sep2017,WACHV,Almacenar el valor con que entro
                    MostrarCriterio()
                Else
                    'MessageBox.Show("El diagnóstico seleccionado no corresponde a los criterios esperados. ", "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                End If

                ''WACHV,INICIO, 21SEPT2017, PARA INVOCAR AL BOTON DE SUGERIR RESPUESTA
                If bMostrar = False Then
                    btnSugerirRespuesta_Click(sender, e)
                Else
                    loadCriterioIngreso(New CriterioIngreso)
                End If
                btnSugerirRespuesta.Visible = bMostrar  ''Se cambio a visible o invisible
                pnlCriteioIngreso.Enabled = bMostrar
                btnGuardar.Visible = bMostrar  ''Se cambio a visible o invisible
                ''WACHV,FIN, 21SEPT2017, PARA INVOCAR AL BOTON DE SUGERIR RESPUESTA
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            Dim Resultado As String
            Dim oCriterioIngreso As New CriterioIngreso()

            ''WACHV, INICIO, 18Sept2017,Validar que sean obligatorias
            If Not bfncObligatoriedad(iCriterio) Then
                MessageBox.Show("Debe seleccionar todas los Respuestas")
                Exit Sub
            End If  ''WACHV, FIN, 18Sept2017,Validar que sean obligatorias

            oCriterioIngreso.cod_pre_sgs = objGeneral.Prestador
            oCriterioIngreso.cod_sucur = objGeneral.Sucursal
            oCriterioIngreso.tip_admision = objPaciente.TipoAdmision

            oCriterioIngreso.ano_adm = objPaciente.AnoAdmision
            oCriterioIngreso.num_adm = objPaciente.NumeroAdmision

            oCriterioIngreso.tip_doc = objPaciente.TipoDocumento
            oCriterioIngreso.Num_doc = objPaciente.NumeroDocumento


            If rbtSiOncologica_Diagnostico.Checked Then
                oCriterioIngreso.Oncologica_Diagnostico = 1
            End If
            If rbtNoOncologica_Diagnostico.Checked Then
                oCriterioIngreso.Oncologica_Diagnostico = 2
            End If
            If rbtSiOncologica_Deterioro.Checked Then
                oCriterioIngreso.Oncologica_Deterioro = 1
            End If
            If rbtNoOncologica_Deterioro.Checked Then
                oCriterioIngreso.Oncologica_Deterioro = 2
            End If
            If rbtSiOncologica_Sintomas.Checked Then
                oCriterioIngreso.Oncologica_Sintomas = 1
            End If
            If rbtNoOncologica_Sintomas.Checked Then
                oCriterioIngreso.Oncologica_Sintomas = 2
            End If
            If rbtSiOncologica_Cumple.Checked Then
                oCriterioIngreso.Oncologica_Cumple = 1
            End If
            If rbtNoOncologica_Cumple.Checked Then
                oCriterioIngreso.Oncologica_Cumple = 2
            End If


            If rbtSiVIHSIDA_Criterio.Checked Then
                oCriterioIngreso.VIHSIDA_Criterio = 1
            End If
            If rbtNoVIHSIDA_Criterio.Checked Then
                oCriterioIngreso.VIHSIDA_Criterio = 2
            End If
            If rbtSiVIHSIDA_Aprobado.Checked Then
                oCriterioIngreso.VIHSIDA_Aprobado = 1
            End If
            If rbtNoVIHSIDA_Aprobado.Checked Then
                oCriterioIngreso.VIHSIDA_Aprobado = 2
            End If
            If rbtSiVIHSIDA_Cumple.Checked Then
                oCriterioIngreso.VIHSIDA_Cumple = 1
            End If
            If rbtNoVIHSIDA_Cumple.Checked Then
                oCriterioIngreso.VIHSIDA_Cumple = 2
            End If
            If rbtSiDemencia_Incapacidad_Vestirse.Checked Then
                oCriterioIngreso.Demencia_Incapacidad_Vestirse = 1
            End If
            If rbtNoDemencia_Incapacidad_Vestirse.Checked Then
                oCriterioIngreso.Demencia_Incapacidad_Vestirse = 2
            End If
            If rbtSiDemencia_Aparicion_Incontinencia.Checked Then
                oCriterioIngreso.Demencia_Aparicion_Incontinencia = 1
            End If
            If rbtNoDemencia_Aparicion_Incontinencia.Checked Then
                oCriterioIngreso.Demencia_Aparicion_Incontinencia = 2
            End If
            If rbtSiDemencia_Incapacidad_Hablar.Checked Then
                oCriterioIngreso.Demencia_Incapacidad_Hablar = 1
            End If
            If rbtNoDemencia_Incapacidad_Hablar.Checked Then
                oCriterioIngreso.Demencia_Incapacidad_Hablar = 2
            End If
            If rbtSiDemencia_Perdida.Checked Then
                oCriterioIngreso.Demencia_Perdida = 1
            End If
            If rbtNoDemencia_Perdida.Checked Then
                oCriterioIngreso.Demencia_Perdida = 2
            End If
            If rbtSiDemencia_Aparicion_Dificultad.Checked Then
                oCriterioIngreso.Demencia_Aparicion_Dificultad = 1
            End If
            If rbtNoDemencia_Aparicion_Dificultad.Checked Then
                oCriterioIngreso.Demencia_Aparicion_Dificultad = 2
            End If
            If rbtSiDemencia_Multiples.Checked Then
                oCriterioIngreso.Demencia_Multiples = 1
            End If
            If rbtNoDemencia_Multiples.Checked Then
                oCriterioIngreso.Demencia_Multiples = 2
            End If
            If rbtSiCumple_Demencia.Checked Then
                oCriterioIngreso.Cumple_Demencia = 1
            End If
            If rbtNoCumple_Demencia.Checked Then
                oCriterioIngreso.Cumple_Demencia = 2
            End If
            If rbtSiParkinson_Deterioro.Checked Then
                oCriterioIngreso.Parkinson_Deterioro = 1
            End If
            If rbtNoParkinson_Deterioro.Checked Then
                oCriterioIngreso.Parkinson_Deterioro = 2
            End If
            If rbtSiParkinson_Sintomas.Checked Then
                oCriterioIngreso.Parkinson_Sintomas = 1
            End If
            If rbtNoParkinson_Sintomas.Checked Then
                oCriterioIngreso.Parkinson_Sintomas = 2
            End If
            If rbtSiParkinson_Problemas.Checked Then
                oCriterioIngreso.Parkinson_Problemas = 1
            End If
            If rbtNoParkinson_Problemas.Checked Then
                oCriterioIngreso.Parkinson_Problemas = 2
            End If
            If rbtSiParkinson_Disfagia.Checked Then
                oCriterioIngreso.Parkinson_Disfagia = 1
            End If
            If rbtNoParkinson_Disfagia.Checked Then
                oCriterioIngreso.Parkinson_Disfagia = 2
            End If
            If rbtSiParkinson_Neumonia.Checked Then
                oCriterioIngreso.Parkinson_Neumonia = 1
            End If
            If rbtNoParkinson_Neumonia.Checked Then
                oCriterioIngreso.Parkinson_Neumonia = 2
            End If
            If rbtSiParkinson_Cumple.Checked Then
                oCriterioIngreso.Parkinson_Cumple = 1
            End If
            If rbtNoParkinson_Cumple.Checked Then
                oCriterioIngreso.Parkinson_Cumple = 2
            End If
            If rbtSiMotoneurona_Deterioro.Checked Then
                oCriterioIngreso.Motoneurona_Deterioro = 1
            End If
            If rbtNoMotoneurona_Deterioro.Checked Then
                oCriterioIngreso.Motoneurona_Deterioro = 2
            End If
            If rbtSiMotoneurona_Sintomas.Checked Then
                oCriterioIngreso.Motoneurona_Sintomas = 1
            End If
            If rbtNoMotoneurona_Sintomas.Checked Then
                oCriterioIngreso.Motoneurona_Sintomas = 2
            End If
            If rbtSiMotoneurona_Problemas.Checked Then
                oCriterioIngreso.Motoneurona_Problemas = 1
            End If
            If rbtNoMotoneurona_Problemas.Checked Then
                oCriterioIngreso.Motoneurona_Problemas = 2
            End If
            If rbtSiMotoneurona_Disfagia.Checked Then
                oCriterioIngreso.Motoneurona_Disfagia = 1
            End If
            If rbtNoMotoneurona_Disfagia.Checked Then
                oCriterioIngreso.Motoneurona_Disfagia = 2
            End If
            If rbtSiMotoneurona_Neumonia.Checked Then
                oCriterioIngreso.Motoneurona_Neumonia = 1
            End If
            If rbtNoMotoneurona_Neumonia.Checked Then
                oCriterioIngreso.Motoneurona_Neumonia = 2
            End If
            If rbtSiMotoneurona_Cumple.Checked Then
                oCriterioIngreso.Motoneurona_Cumple = 1
            End If
            If rbtNoMotoneurona_Cumple.Checked Then
                oCriterioIngreso.Motoneurona_Cumple = 2
            End If
            If rbtSiEsclerosis_Multiple_Deterioro.Checked Then
                oCriterioIngreso.Esclerosis_Multiple_Deterioro = 1
            End If
            If rbtNoEsclerosis_Multiple_Deterioro.Checked Then
                oCriterioIngreso.Esclerosis_Multiple_Deterioro = 2
            End If
            If rbtSiEsclerosis_Multiple_Sintomas.Checked Then
                oCriterioIngreso.Esclerosis_Multiple_Sintomas = 1
            End If
            If rbtNoEsclerosis_Multiple_Sintomas.Checked Then
                oCriterioIngreso.Esclerosis_Multiple_Sintomas = 2
            End If
            If rbtSiEsclerosis_Multiple_Problemas.Checked Then
                oCriterioIngreso.Esclerosis_Multiple_Problemas = 1
            End If
            If rbtNoEsclerosis_Multiple_Problemas.Checked Then
                oCriterioIngreso.Esclerosis_Multiple_Problemas = 2
            End If
            If rbtSiEsclerosis_Multiple_Disfagia.Checked Then
                oCriterioIngreso.Esclerosis_Multiple_Disfagia = 1
            End If
            If rbtNoEsclerosis_Multiple_Disfagia.Checked Then
                oCriterioIngreso.Esclerosis_Multiple_Disfagia = 2
            End If
            If rbtSiEsclerosis_Multiple_Neumonia.Checked Then
                oCriterioIngreso.Esclerosis_Multiple_Neumonia = 1
            End If
            If rbtNoEsclerosis_Multiple_Neumonia.Checked Then
                oCriterioIngreso.Esclerosis_Multiple_Neumonia = 2
            End If
            If rbtSiEsclerosis_Multiple_Cumple.Checked Then
                oCriterioIngreso.Esclerosis_Multiple_Cumple = 1
            End If
            If rbtNoEsclerosis_Multiple_Cumple.Checked Then
                oCriterioIngreso.Esclerosis_Multiple_Cumple = 2
            End If
            If rbtSiCardiaca_Cronica_Insuficiencia_Cardiaca.Checked Then
                oCriterioIngreso.Cardiaca_Cronica_Insuficiencia_Cardiaca = 1
            End If
            If rbtNoCardiaca_Cronica_Insuficiencia_Cardiaca.Checked Then
                oCriterioIngreso.Cardiaca_Cronica_Insuficiencia_Cardiaca = 2
            End If
            If rbtSiCardiaca_Cronica_Disnea.Checked Then
                oCriterioIngreso.Cardiaca_Cronica_Disnea = 1
            End If
            If rbtNoCardiaca_Cronica_Disnea.Checked Then
                oCriterioIngreso.Cardiaca_Cronica_Disnea = 2
            End If
            If rbtSiCardiaca_Cronica_Sintomas.Checked Then
                oCriterioIngreso.Cardiaca_Cronica_Sintomas = 1
            End If
            If rbtNoCardiaca_Cronica_Sintomas.Checked Then
                oCriterioIngreso.Cardiaca_Cronica_Sintomas = 2
            End If
            If rbtSiCardiaca_Cronica_Ecocardiograma.Checked Then
                oCriterioIngreso.Cardiaca_Cronica_Ecocardiograma = 1
            End If
            If rbtNoCardiaca_Cronica_Ecocardiograma.Checked Then
                oCriterioIngreso.Cardiaca_Cronica_Ecocardiograma = 2
            End If
            If rbtSiCardiaca_Cronica_Insuficiencia_Renal.Checked Then
                oCriterioIngreso.Cardiaca_Cronica_Insuficiencia_Renal = 1
            End If
            If rbtNoCardiaca_Cronica_Insuficiencia_Renal.Checked Then
                oCriterioIngreso.Cardiaca_Cronica_Insuficiencia_Renal = 2
            End If
            If rbtSiCardiaca_Cronica_Ingresos.Checked Then
                oCriterioIngreso.Cardiaca_Cronica_Ingresos = 1
            End If
            If rbtNoCardiaca_Cronica_Ingresos.Checked Then
                oCriterioIngreso.Cardiaca_Cronica_Ingresos = 2
            End If
            If rbtSiCardiaca_Cronica_Cumple.Checked Then
                oCriterioIngreso.Cardiaca_Cronica_Cumple = 1
            End If
            If rbtNoCardiaca_Cronica_Cumple.Checked Then
                oCriterioIngreso.Cardiaca_Cronica_Cumple = 2
            End If
            If rbtSiCerebro_Vascular_Cumple_Fragilidad.Checked Then
                oCriterioIngreso.Cerebro_Vascular_Cumple_Fragilidad = 1
            End If
            If rbtNoCerebro_Vascular_Cumple_Fragilidad.Checked Then
                oCriterioIngreso.Cerebro_Vascular_Cumple_Fragilidad = 2
            End If
            If rbtSiCerebro_Vascular_Aprobado.Checked Then
                oCriterioIngreso.Cerebro_Vascular_Aprobado = 1
            End If
            If rbtNoCerebro_Vascular_Aprobado.Checked Then
                oCriterioIngreso.Cerebro_Vascular_Aprobado = 2
            End If
            If rbtSiCerebro_Vascular_Cumple.Checked Then
                oCriterioIngreso.Cerebro_Vascular_Cumple = 1
            End If
            If rbtNoCerebro_Vascular_Cumple.Checked Then
                oCriterioIngreso.Cerebro_Vascular_Cumple = 2
            End If
            If rbtSiPulmonar_Cronica_Disnea.Checked Then
                oCriterioIngreso.Pulmonar_Cronica_Disnea = 1
            End If
            If rbtNoPulmonar_Cronica_Disnea.Checked Then
                oCriterioIngreso.Pulmonar_Cronica_Disnea = 2
            End If
            If rbtSiPulmonar_Cronica_Sintomas.Checked Then
                oCriterioIngreso.Pulmonar_Cronica_Sintomas = 1
            End If
            If rbtNoPulmonar_Cronica_Sintomas.Checked Then
                oCriterioIngreso.Pulmonar_Cronica_Sintomas = 2
            End If
            If rbtSiPulmonar_Cronica_Criterios.Checked Then ''WACHV, 04OCT2017, VA LAS RESPUESTA DE LA PREGUNTA Criterios de oxigenoterapia domiciliaria permanente
                oCriterioIngreso.Pulmonar_Cronica_Criterios = 1
            End If
            If rbtNoPulmonar_Cronica_Criterios.Checked Then   ''WACHV, 04OCT2017, VA LAS RESPUESTA DE LA PREGUNTA Criterios de oxigenoterapia domiciliaria permanente
                oCriterioIngreso.Pulmonar_Cronica_Criterios = 2
            End If
            If rbtSiPulmonar_Cronica_En.Checked Then   ''WACHV, 04OCT2017, VA LAS RESPUESTA DE LA PREGUNTA En caso de disponer de pruebas funcionales .....
                oCriterioIngreso.Pulmonar_Cronica_En = 1
            End If
            If rbtNoPulmonar_Cronica_En.Checked Then ''WACHV, 04OCT2017, VA LAS RESPUESTA DE LA PREGUNTA En caso de disponer de pruebas funcionales .....
                oCriterioIngreso.Pulmonar_Cronica_En = 2
            End If
            If rbtSiPulmonar_Cronica_Insuficiencia.Checked Then
                oCriterioIngreso.Pulmonar_Cronica_Insuficiencia = 1
            End If
            If rbtNoPulmonar_Cronica_Insuficiencia.Checked Then
                oCriterioIngreso.Pulmonar_Cronica_Insuficiencia = 2
            End If
            If rbtSiPulmonar_Cronica_Ingresos.Checked Then
                oCriterioIngreso.Pulmonar_Cronica_Ingresos = 1
            End If
            If rbtNoPulmonar_Cronica_Ingresos.Checked Then
                oCriterioIngreso.Pulmonar_Cronica_Ingresos = 2
            End If
            If rbtSiPulmonar_Cronica_Cumple.Checked Then
                oCriterioIngreso.Pulmonar_Cronica_Cumple = 1
            End If
            If rbtNoPulmonar_Cronica_Cumple.Checked Then
                oCriterioIngreso.Pulmonar_Cronica_Cumple = 2
            End If
            If rbtSiHepatica_Cronica_Cirrosis.Checked Then
                oCriterioIngreso.Hepatica_Cronica_Cirrosis = 1
            End If
            If rbtNoHepatica_Cronica_Cirrosis.Checked Then
                oCriterioIngreso.Hepatica_Cronica_Cirrosis = 2
            End If
            If rbtSiHepatica_Cronica_Puntuacion.Checked Then
                oCriterioIngreso.Hepatica_Cronica_Puntuacion = 1
            End If
            If rbtNoHepatica_Cronica_Puntuacion.Checked Then
                oCriterioIngreso.Hepatica_Cronica_Puntuacion = 2
            End If
            If rbtSiHepatica_Cronica_Presencia.Checked Then
                oCriterioIngreso.Hepatica_Cronica_Presencia = 1
            End If
            If rbtNoHepatica_Cronica_Presencia.Checked Then
                oCriterioIngreso.Hepatica_Cronica_Presencia = 2
            End If
            If rbtSiHepatica_Cronica_Carcinoma.Checked Then
                oCriterioIngreso.Hepatica_Cronica_Carcinoma = 1
            End If
            If rbtNoHepatica_Cronica_Carcinoma.Checked Then
                oCriterioIngreso.Hepatica_Cronica_Carcinoma = 2
            End If
            If rbtSiHepatica_Cronica_Cumple.Checked Then
                oCriterioIngreso.Hepatica_Cronica_Cumple = 1
            End If
            If rbtNoHepatica_Cronica_Cumple.Checked Then
                oCriterioIngreso.Hepatica_Cronica_Cumple = 2
            End If
            If rbtSiRenal_Cronica_Insuficiencia.Checked Then
                oCriterioIngreso.Renal_Cronica_Insuficiencia = 1
            End If
            If rbtNoRenal_Cronica_Insuficiencia.Checked Then
                oCriterioIngreso.Renal_Cronica_Insuficiencia = 2
            End If
            'WACHV, INICIO, 19SEPT2017, Nuevas preguntas
            If rbtSiRenal_Cronica_CriterioFragilidadSevera.Checked Then
                oCriterioIngreso.Renal_Cronica_CriterioFragilidadSevera = 1
            End If
            If rbtNoRenal_Cronica_CriterioFragilidadSevera.Checked Then
                oCriterioIngreso.Renal_Cronica_CriterioFragilidadSevera = 2
            End If
            If rbtSiRenal_Cronica_AprobadoJuntaPaliativa.Checked Then
                oCriterioIngreso.Renal_Cronica_AprobadoJuntaPaliativa = 1
            End If
            If rbtNoRenal_Cronica_AprobadoJuntaPaliativa.Checked Then
                oCriterioIngreso.Renal_Cronica_AprobadoJuntaPaliativa = 2
            End If
            'WACHV, FIN, 19SEPT2017, Nuevas preguntas

            If rbtSiRenal_Cronica_Cumple.Checked Then
                oCriterioIngreso.Renal_Cronica_Cumple = 1
            End If
            If rbtNoRenal_Cronica_Cumple.Checked Then
                oCriterioIngreso.Renal_Cronica_Cumple = 2
            End If
            If rbtSiFragilidad_Severa_Deterioro.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Deterioro = 1
            End If
            If rbtNoFragilidad_Severa_Deterioro.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Deterioro = 2
            End If
            If rbtSiFragilidad_Severa_Perdida_Peso.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Perdida_Peso = 1
            End If
            If rbtNoFragilidad_Severa_Perdida_Peso.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Perdida_Peso = 2
            End If
            If rbtSiFragilidad_Severa_Albumina.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Albumina = 1
            End If
            If rbtNoFragilidad_Severa_Albumina.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Albumina = 2
            End If

            If rbtSDFragilidad_Severa_Albumina.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Albumina = 3
            End If

            If rbtSiFragilidad_Severa_Impresion.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Impresion = 1
            End If
            If rbtNoFragilidad_Severa_Impresion.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Impresion = 2
            End If
            If rbtSiFragilidad_Severa_Barthel.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Barthel = 1
            End If
            If rbtNoFragilidad_Severa_Barthel.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Barthel = 2
            End If
            If rbtSiFragilidad_Severa_Pps.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Pps = 1
            End If
            If rbtNoFragilidad_Severa_Pps.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Pps = 2
            End If
            If rbtSiFragilidad_Severa_Perdida_Actividades.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Perdida_Actividades = 1
            End If
            If rbtNoFragilidad_Severa_Perdida_Actividades.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Perdida_Actividades = 2
            End If
            If rbtSiFragilidad_Severa_Ulceras.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Ulceras = 1
            End If
            If rbtNoFragilidad_Severa_Ulceras.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Ulceras = 2
            End If
            If rbtSiFragilidad_Severa_Infecciones.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Infecciones = 1
            End If
            If rbtNoFragilidad_Severa_Infecciones.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Infecciones = 2
            End If
            If rbtSiFragilidad_Severa_Delirium.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Delirium = 1
            End If
            If rbtNoFragilidad_Severa_Delirium.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Delirium = 2
            End If
            If rbtSiFragilidad_Severa_Disfagia.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Disfagia = 1
            End If
            If rbtNoFragilidad_Severa_Disfagia.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Disfagia = 2
            End If
            If rbtSiFragilidad_Severa_Caidas.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Caidas = 1
            End If
            If rbtNoFragilidad_Severa_Caidas.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Caidas = 2
            End If
            If rbtSiFragilidad_Severa_Sintomas.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Sintomas = 1
            End If
            If rbtNoFragilidad_Severa_Sintomas.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Sintomas = 2
            End If
            If rbtSiFragilidad_Severa_Mas_Ingresos.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Mas_Ingresos = 1
            End If
            If rbtNoFragilidad_Severa_Mas_Ingresos.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Mas_Ingresos = 2
            End If
            If rbtSiFragilidad_Severa_Necesidad.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Necesidad = 1
            End If
            If rbtNoFragilidad_Severa_Necesidad.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Necesidad = 2
            End If
            If rbtSiFragilidad_Severa_Mas_Patologias.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Mas_Patologias = 1
            End If
            If rbtNoFragilidad_Severa_Mas_Patologias.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Mas_Patologias = 2
            End If
            If rbtSiFragilidad_Severa_Cumple.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Cumple = 1
            End If
            If rbtNoFragilidad_Severa_Cumple.Checked Then
                oCriterioIngreso.Fragilidad_Severa_Cumple = 2
            End If

            oCriterioIngreso.login = objGeneral.Login
            oCriterioIngreso.obs = String.Empty

            Resultado = oCriterioIngreso.GuardarCriterioIngreso(oCriterioIngreso)

            If Resultado = String.Empty Then
                MessageBox.Show("La información ingresada fue guardada exitosamente. ", "Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MarcarRespuestas(False)
                loadCriterioIngreso(New CriterioIngreso)
                Me.ParentForm.Close() ''INICIO, WACHV, 28AGO2017, Cierra el Formulario que contiene el control.
            End If

        Catch ex As Exception
            MessageBox.Show("No se pudo guardar la información ingresada. ", "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

        End Try
    End Sub

    Public Sub btnSugerirRespuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSugerirRespuesta.Click
        fncSugerirRespuesta() '''WACHV,20SEPT2017, LLAMADA A FUNCION
    End Sub
    ''' <summary>
    ''' WACHV,20SEPT2017, SE CREA FUNCION PARA SER LLAMADA
    ''' </summary>
    ''' <returns></returns>
    Public Function fncSugerirRespuesta()
        Try
            Dim oCriterioIngreso As New CriterioIngreso()
            loadCriterioIngreso(oCriterioIngreso.SugerirRespuesta(objGeneral, objPaciente))

        Catch ex As Exception
            MessageBox.Show("No fue posible consultar las últimas respuestas de este paciente.", "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

        End Try
    End Function



#Region "RbtSi"

    Private Sub rbtSiOncologica_DiagnosticoCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiOncologica_Diagnostico.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoOncologica()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiOncologica_DeterioroCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiOncologica_Deterioro.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoOncologica()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiOncologica_SintomasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiOncologica_Sintomas.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoOncologica()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtSiVIHSIDA_Criterio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiVIHSIDA_Criterio.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoVIHSIDA()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiVIHSIDA_AprobadoCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiVIHSIDA_Aprobado.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoVIHSIDA()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtSiDemencia_Incapacidad_Vestirse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiDemencia_Incapacidad_Vestirse.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoDemencia()
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiDemencia_Aparicion_IncontinenciaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiDemencia_Aparicion_Incontinencia.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoDemencia()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiDemencia_Incapacidad_HablarCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiDemencia_Incapacidad_Hablar.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoDemencia()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtSiDemencia_PerdidaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiDemencia_Perdida.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoDemencia()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiDemencia_Aparicion_DificultadCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiDemencia_Aparicion_Dificultad.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoDemencia()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtSiDemencia_MultiplesCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiDemencia_Multiples.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoDemencia()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtSiParkinson_DeterioroCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiParkinson_Deterioro.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iParkinson = 0
                MarcaCumplimientoGrupoParkinson()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiParkinson_SintomasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiParkinson_Sintomas.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iParkinson = 0
                MarcaCumplimientoGrupoParkinson()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiParkinson_ProblemasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiParkinson_Problemas.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iParkinson = 0
                MarcaCumplimientoGrupoParkinson()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiParkinson_DisfagiaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiParkinson_Disfagia.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iParkinson = 0
                MarcaCumplimientoGrupoParkinson()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiParkinson_NeumoniaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiParkinson_Neumonia.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iParkinson = 0
                MarcaCumplimientoGrupoParkinson()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtSiMotoneurona_DeterioroCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiMotoneurona_Deterioro.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iMotoNeurona = 0
                MarcaCumplimientoGrupoMotoneurona()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiMotoneurona_SintomasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiMotoneurona_Sintomas.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iMotoNeurona = 0
                MarcaCumplimientoGrupoMotoneurona()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiMotoneurona_ProblemasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiMotoneurona_Problemas.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iMotoNeurona = 0
                MarcaCumplimientoGrupoMotoneurona()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiMotoneurona_DisfagiaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiMotoneurona_Disfagia.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iMotoNeurona = 0
                MarcaCumplimientoGrupoMotoneurona()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiMotoneurona_NeumoniaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiMotoneurona_Neumonia.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iMotoNeurona = 0
                MarcaCumplimientoGrupoMotoneurona()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtSiEsclerosis_Multiple_DeterioroCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiEsclerosis_Multiple_Deterioro.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iEsclerosis = 0
                MarcaCumplimientoGrupoEsclerosis()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiEsclerosis_Multiple_SintomasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiEsclerosis_Multiple_Sintomas.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iEsclerosis = 0
                MarcaCumplimientoGrupoEsclerosis()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiEsclerosis_Multiple_ProblemasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiEsclerosis_Multiple_Problemas.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iEsclerosis = 0
                MarcaCumplimientoGrupoEsclerosis()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiEsclerosis_Multiple_DisfagiaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiEsclerosis_Multiple_Disfagia.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iEsclerosis = 0
                MarcaCumplimientoGrupoEsclerosis()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiEsclerosis_Multiple_NeumoniaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiEsclerosis_Multiple_Neumonia.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iEsclerosis = 0
                MarcaCumplimientoGrupoEsclerosis()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtSiCardiaca_Cronica_Insuficiencia_CardiacaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiCardiaca_Cronica_Insuficiencia_Cardiaca.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iCardiaca = 0
                MarcaCumplimientoGrupoCardiaca()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiCardiaca_Cronica_DisneaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiCardiaca_Cronica_Disnea.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iCardiaca = 0
                MarcaCumplimientoGrupoCardiaca()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiCardiaca_Cronica_SintomasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiCardiaca_Cronica_Sintomas.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iCardiaca = 0
                MarcaCumplimientoGrupoCardiaca()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiCardiaca_Cronica_EcocardiogramaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiCardiaca_Cronica_Ecocardiograma.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iCardiaca = 0
                MarcaCumplimientoGrupoCardiaca()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiCardiaca_Cronica_Insuficiencia_RenalCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiCardiaca_Cronica_Insuficiencia_Renal.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iParkinson = 0
                MarcaCumplimientoGrupoCardiaca()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiCardiaca_Cronica_IngresosCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiCardiaca_Cronica_Ingresos.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iCardiaca = 0
                MarcaCumplimientoGrupoCardiaca()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtSiCerebro_Vascular_Cumple_FragilidadCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiCerebro_Vascular_Cumple_Fragilidad.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iCerebroVascular = 0
                MarcaCumplimientoGrupoCerebro()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiCerebro_Vascular_AprobadoCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiCerebro_Vascular_Aprobado.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iCerebroVascular = 0
                MarcaCumplimientoGrupoCerebro()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtSiPulmonar_Cronica_DisneaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiPulmonar_Cronica_Disnea.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iPulmonar = 0
                MarcaCumplimientoGrupoPulmonar()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiPulmonar_Cronica_SintomasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiPulmonar_Cronica_Sintomas.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iPulmonar = 0
                MarcaCumplimientoGrupoPulmonar()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiPulmonar_Cronica_CriteriosCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiPulmonar_Cronica_Criterios.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iPulmonar = 0
                MarcaCumplimientoGrupoPulmonar()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiPulmonar_Cronica_EnCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiPulmonar_Cronica_En.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iPulmonar = 0
                MarcaCumplimientoGrupoPulmonar()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiPulmonar_Cronica_InsuficienciaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiPulmonar_Cronica_Insuficiencia.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iPulmonar = 0
                MarcaCumplimientoGrupoPulmonar()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiPulmonar_Cronica_IngresosCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiPulmonar_Cronica_Ingresos.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                iPulmonar = 0
                MarcaCumplimientoGrupoPulmonar()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtSiHepatica_Cronica_CirrosisCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiHepatica_Cronica_Cirrosis.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoHepatica()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiHepatica_Cronica_PuntuacionCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiHepatica_Cronica_Puntuacion.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoHepatica()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiHepatica_Cronica_PresenciaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiHepatica_Cronica_Presencia.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoHepatica()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiHepatica_Cronica_CarcinomaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiHepatica_Cronica_Carcinoma.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoHepatica()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtSiRenal_Cronica_InsuficienciaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiRenal_Cronica_Insuficiencia.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoRenal()
            End If
        Catch ex As Exception
        End Try
    End Sub


    '''' WACHV, 19SEPT2017,SE AGREGA NUEVA PREGUNTAS
    Private Sub rbtSiRenal_Cronica_CriterioFragilidadSevera_CheckedChanged(sender As Object, e As EventArgs) Handles rbtSiRenal_Cronica_CriterioFragilidadSevera.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoRenal()
            End If
        Catch ex As Exception
        End Try
    End Sub
    '''' WACHV, 19SEPT2017,SE AGREGA NUEVA PREGUNTAS
    Private Sub rbtSiRenal_Cronica_AprobadoJuntaPaliativa_CheckedChanged(sender As Object, e As EventArgs) Handles rbtSiRenal_Cronica_AprobadoJuntaPaliativa.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoRenal()
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub rbtSiFragilidad_Severa_DeterioroCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiFragilidad_Severa_Deterioro.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiFragilidad_Severa_Perdida_PesoCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiFragilidad_Severa_Perdida_Peso.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiFragilidad_Severa_AlbuminaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiFragilidad_Severa_Albumina.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiFragilidad_Severa_ImpresionCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiFragilidad_Severa_Impresion.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiFragilidad_Severa_BarthelCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiFragilidad_Severa_Barthel.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiFragilidad_Severa_PpsCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiFragilidad_Severa_Pps.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiFragilidad_Severa_Perdida_ActividadesCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiFragilidad_Severa_Perdida_Actividades.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiFragilidad_Severa_UlcerasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiFragilidad_Severa_Ulceras.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiFragilidad_Severa_InfeccionesCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiFragilidad_Severa_Infecciones.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiFragilidad_Severa_DeliriumCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiFragilidad_Severa_Delirium.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiFragilidad_Severa_DisfagiaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiFragilidad_Severa_Disfagia.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiFragilidad_Severa_CaidasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiFragilidad_Severa_Caidas.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiFragilidad_Severa_SintomasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiFragilidad_Severa_Sintomas.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiFragilidad_Severa_Mas_IngresosCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiFragilidad_Severa_Mas_Ingresos.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiFragilidad_Severa_NecesidadCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiFragilidad_Severa_Necesidad.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtSiFragilidad_Severa_Mas_PatologiasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiFragilidad_Severa_Mas_Patologias.CheckedChanged
        Try
            If sender.Text = "Si" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "RbtNO"

    Private Sub rbtNoOncologica_DiagnosticoCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoOncologica_Diagnostico.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoOncologica()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoOncologica_DeterioroCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoOncologica_Deterioro.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoOncologica()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoOncologica_SintomasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoOncologica_Sintomas.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoOncologica()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtNoVIHSIDA_CriterioCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoVIHSIDA_Criterio.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoVIHSIDA()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoVIHSIDA_AprobadoCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoVIHSIDA_Aprobado.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoVIHSIDA()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtNoDemencia_Incapacidad_VestirseCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoDemencia_Incapacidad_Vestirse.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoDemencia()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoDemencia_Aparicion_IncontinenciaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoDemencia_Aparicion_Incontinencia.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoDemencia()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoDemencia_Incapacidad_HablarCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoDemencia_Incapacidad_Hablar.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoDemencia()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtNoDemencia_PerdidaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoDemencia_Perdida.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoDemencia()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoDemencia_Aparicion_DificultadCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoDemencia_Aparicion_Dificultad.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoDemencia()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtNoDemencia_MultiplesCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoDemencia_Multiples.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoDemencia()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtNoParkinson_DeterioroCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoParkinson_Deterioro.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iParkinson = 0
                MarcaCumplimientoGrupoParkinson()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoParkinson_SintomasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoParkinson_Sintomas.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iParkinson = 0
                MarcaCumplimientoGrupoParkinson()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoParkinson_ProblemasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoParkinson_Problemas.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iParkinson = 0
                MarcaCumplimientoGrupoParkinson()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoParkinson_DisfagiaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoParkinson_Disfagia.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iParkinson = 0
                MarcaCumplimientoGrupoParkinson()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoParkinson_NeumoniaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoParkinson_Neumonia.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iParkinson = 0
                MarcaCumplimientoGrupoParkinson()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtNoMotoneurona_DeterioroCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoMotoneurona_Deterioro.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iMotoNeurona = 0
                MarcaCumplimientoGrupoMotoneurona()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoMotoneurona_SintomasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoMotoneurona_Sintomas.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iMotoNeurona = 0
                MarcaCumplimientoGrupoMotoneurona()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoMotoneurona_ProblemasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoMotoneurona_Problemas.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iMotoNeurona = 0
                MarcaCumplimientoGrupoMotoneurona()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoMotoneurona_DisfagiaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoMotoneurona_Disfagia.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iMotoNeurona = 0
                MarcaCumplimientoGrupoMotoneurona()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoMotoneurona_NeumoniaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoMotoneurona_Neumonia.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iMotoNeurona = 0
                MarcaCumplimientoGrupoMotoneurona()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtNoEsclerosis_Multiple_DeterioroCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoEsclerosis_Multiple_Deterioro.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iEsclerosis = 0
                MarcaCumplimientoGrupoEsclerosis()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoEsclerosis_Multiple_SintomasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoEsclerosis_Multiple_Sintomas.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iEsclerosis = 0
                MarcaCumplimientoGrupoEsclerosis()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoEsclerosis_Multiple_ProblemasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoEsclerosis_Multiple_Problemas.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iEsclerosis = 0
                MarcaCumplimientoGrupoEsclerosis()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoEsclerosis_Multiple_DisfagiaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoEsclerosis_Multiple_Disfagia.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iEsclerosis = 0
                MarcaCumplimientoGrupoEsclerosis()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoEsclerosis_Multiple_NeumoniaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoEsclerosis_Multiple_Neumonia.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iEsclerosis = 0
                MarcaCumplimientoGrupoEsclerosis()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtNoCardiaca_Cronica_Insuficiencia_CardiacaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoCardiaca_Cronica_Insuficiencia_Cardiaca.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iCardiaca = 0
                MarcaCumplimientoGrupoCardiaca()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoCardiaca_Cronica_DisneaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoCardiaca_Cronica_Disnea.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iCardiaca = 0
                MarcaCumplimientoGrupoCardiaca()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoCardiaca_Cronica_SintomasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoCardiaca_Cronica_Sintomas.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iCardiaca = 0
                MarcaCumplimientoGrupoCardiaca()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoCardiaca_Cronica_EcocardiogramaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoCardiaca_Cronica_Ecocardiograma.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iCardiaca = 0
                MarcaCumplimientoGrupoCardiaca()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoCardiaca_Cronica_Insuficiencia_RenalCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoCardiaca_Cronica_Insuficiencia_Renal.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iCardiaca = 0
                MarcaCumplimientoGrupoCardiaca()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoCardiaca_Cronica_IngresosCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoCardiaca_Cronica_Ingresos.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iCardiaca = 0
                MarcaCumplimientoGrupoCardiaca()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtNoCerebro_Vascular_Cumple_FragilidadCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoCerebro_Vascular_Cumple_Fragilidad.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iCerebroVascular = 0
                MarcaCumplimientoGrupoCerebro()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoCerebro_Vascular_AprobadoCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoCerebro_Vascular_Aprobado.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iCerebroVascular = 0
                MarcaCumplimientoGrupoCerebro()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtNoPulmonar_Cronica_DisneaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoPulmonar_Cronica_Disnea.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iPulmonar = 0
                MarcaCumplimientoGrupoPulmonar()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoPulmonar_Cronica_SintomasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoPulmonar_Cronica_Sintomas.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iPulmonar = 0
                MarcaCumplimientoGrupoPulmonar()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoPulmonar_Cronica_CriteriosCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoPulmonar_Cronica_Criterios.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iPulmonar = 0
                MarcaCumplimientoGrupoPulmonar()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoPulmonar_Cronica_EnCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoPulmonar_Cronica_En.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iPulmonar = 0
                MarcaCumplimientoGrupoPulmonar()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoPulmonar_Cronica_InsuficienciaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoPulmonar_Cronica_Insuficiencia.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iPulmonar = 0
                MarcaCumplimientoGrupoPulmonar()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoPulmonar_Cronica_IngresosCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoPulmonar_Cronica_Ingresos.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                iPulmonar = 0
                MarcaCumplimientoGrupoPulmonar()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtNoHepatica_Cronica_CirrosisCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoHepatica_Cronica_Cirrosis.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoHepatica()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoHepatica_Cronica_PuntuacionCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoHepatica_Cronica_Puntuacion.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoHepatica()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoHepatica_Cronica_PresenciaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoHepatica_Cronica_Presencia.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoHepatica()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoHepatica_Cronica_CarcinomaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoHepatica_Cronica_Carcinoma.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoHepatica()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbtNoRenal_Cronica_InsuficienciaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoRenal_Cronica_Insuficiencia.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoRenal()
            End If
        Catch ex As Exception
        End Try
    End Sub

    ''WACHV,19SEPT2017, SE AGREGA NUEVA PREGUNTA
    Private Sub rbtNoRenal_Cronica_CriterioFragilidadSevera_CheckedChanged(sender As Object, e As EventArgs) Handles rbtNoRenal_Cronica_CriterioFragilidadSevera.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoRenal()
            End If
        Catch ex As Exception
        End Try
    End Sub
    ''WACHV,19SEPT2017, SE AGREGA NUEVA PREGUNTA
    Private Sub rbtNoRenal_Cronica_AprobadoJuntaPaliativa_CheckedChanged(sender As Object, e As EventArgs) Handles rbtNoRenal_Cronica_AprobadoJuntaPaliativa.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoRenal()
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub rbtNoFragilidad_Severa_DeterioroCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoFragilidad_Severa_Deterioro.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoFragilidad_Severa_Perdida_PesoCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoFragilidad_Severa_Perdida_Peso.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoFragilidad_Severa_AlbuminaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoFragilidad_Severa_Albumina.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoFragilidad_Severa_ImpresionCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoFragilidad_Severa_Impresion.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoFragilidad_Severa_BarthelCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoFragilidad_Severa_Barthel.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoFragilidad_Severa_PpsCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoFragilidad_Severa_Pps.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoFragilidad_Severa_Perdida_ActividadesCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoFragilidad_Severa_Perdida_Actividades.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoFragilidad_Severa_UlcerasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoFragilidad_Severa_Ulceras.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoFragilidad_Severa_InfeccionesCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoFragilidad_Severa_Infecciones.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoFragilidad_Severa_DeliriumCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoFragilidad_Severa_Delirium.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoFragilidad_Severa_DisfagiaCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoFragilidad_Severa_Disfagia.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoFragilidad_Severa_CaidasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoFragilidad_Severa_Caidas.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoFragilidad_Severa_SintomasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoFragilidad_Severa_Sintomas.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoFragilidad_Severa_Mas_IngresosCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoFragilidad_Severa_Mas_Ingresos.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoFragilidad_Severa_NecesidadCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoFragilidad_Severa_Necesidad.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbtNoFragilidad_Severa_Mas_PatologiasCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoFragilidad_Severa_Mas_Patologias.CheckedChanged
        Try
            If sender.Text = "No" And sender.Checked Then
                MarcaCumplimientoGrupoFragilidad()
            End If
        Catch ex As Exception
        End Try
    End Sub

#End Region

#End Region

#Region "Functions"

    ''' <summary>
    ''' Muestra el panel del criterio que corresponde al diagnostico seleccionado
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MostrarCriterio()
        Try
            grbEnfermedad_Oncologica.Visible = False
            grbDemencia.Visible = False
            grbMotoneurona.Visible = False
            grbCardiaca_Cronica.Visible = False
            grbHepatica_Cronica.Visible = False
            grbPulmonar_Cronica.Visible = False
            grbRenal_Cronica.Visible = False
            grbEsclerosis_Multiple.Visible = False
            grbCerebro_Vascular.Visible = False
            grbFragilidad_Severa.Visible = False
            grbParkinson.Visible = False
            grbVIHSIDA.Visible = False

            Select Case CriterioIngreso
                Case Criterio.Enfermedad_Oncologica
                    grbEnfermedad_Oncologica.Visible = True
                    grbEnfermedad_Oncologica.Location = New Point(3, 50)
                    btnGuardar.Location = New Point(705, grbEnfermedad_Oncologica.Size.Height + 80)
                    pnlCriteioIngreso.Size = New Size(grbEnfermedad_Oncologica.Size.Width + 5, grbEnfermedad_Oncologica.Size.Height + 180)
                    Me.Size = New Size(grbEnfermedad_Oncologica.Size.Width + 5, grbEnfermedad_Oncologica.Size.Height + 180)

                Case Criterio.VIHSIDA
                    grbVIHSIDA.Visible = True
                    grbVIHSIDA.Location = New Point(3, 50)
                    btnGuardar.Location = New Point(710, grbVIHSIDA.Size.Height + 80)
                    pnlCriteioIngreso.Size = New Size(grbVIHSIDA.Size.Width + 5, grbVIHSIDA.Size.Height + 180)
                    Me.Size = New Size(grbVIHSIDA.Size.Width + 5, grbVIHSIDA.Size.Height + 180)

                Case Criterio.Demencia
                    grbDemencia.Visible = True
                    grbDemencia.Location = New Point(3, 50)
                    btnGuardar.Location = New Point(710, grbDemencia.Size.Height + 80)
                    pnlCriteioIngreso.Size = New Size(grbDemencia.Size.Width + 5, grbDemencia.Size.Height + 180)
                    Me.Size = New Size(grbDemencia.Size.Width + 5, grbDemencia.Size.Height + 180)

                Case Criterio.Parkinson
                    grbParkinson.Visible = True
                    grbParkinson.Location = New Point(3, 50)
                    btnGuardar.Location = New Point(710, grbParkinson.Size.Height + 80)
                    pnlCriteioIngreso.Size = New Size(grbParkinson.Size.Width + 5, grbParkinson.Size.Height + 180)
                    Me.Size = New Size(grbParkinson.Size.Width + 5, grbParkinson.Size.Height + 180)

                Case Criterio.Enfermedad_de_Motoneurona
                    grbMotoneurona.Visible = True
                    grbMotoneurona.Location = New Point(3, 50)
                    btnGuardar.Location = New Point(710, grbMotoneurona.Size.Height + 80)
                    pnlCriteioIngreso.Size = New Size(grbMotoneurona.Size.Width + 5, grbMotoneurona.Size.Height + 180)
                    Me.Size = New Size(grbMotoneurona.Size.Width + 5, grbMotoneurona.Size.Height + 180)

                Case Criterio.Esclerosis_Multiple
                    grbEsclerosis_Multiple.Visible = True
                    grbEsclerosis_Multiple.Location = New Point(3, 50)
                    btnGuardar.Location = New Point(710, grbEsclerosis_Multiple.Size.Height + 80)
                    pnlCriteioIngreso.Size = New Size(grbEsclerosis_Multiple.Size.Width + 5, grbEsclerosis_Multiple.Size.Height + 180)
                    Me.Size = New Size(grbEsclerosis_Multiple.Size.Width + 5, grbEsclerosis_Multiple.Size.Height + 180)

                Case Criterio.Enfermedad_Cardiaca_Cronica
                    grbCardiaca_Cronica.Visible = True
                    grbCardiaca_Cronica.Location = New Point(3, 50)
                    btnGuardar.Location = New Point(710, grbCardiaca_Cronica.Size.Height + 80)
                    pnlCriteioIngreso.Size = New Size(grbCardiaca_Cronica.Size.Width + 5, grbCardiaca_Cronica.Size.Height + 180)
                    Me.Size = New Size(grbCardiaca_Cronica.Size.Width + 5, grbCardiaca_Cronica.Size.Height + 180)

                Case Criterio.Evento_Cerebrovalsular
                    grbCerebro_Vascular.Visible = True
                    grbCerebro_Vascular.Location = New Point(3, 50)
                    btnGuardar.Location = New Point(710, grbCerebro_Vascular.Size.Height + 80)
                    pnlCriteioIngreso.Size = New Size(grbCerebro_Vascular.Size.Width + 5, grbCerebro_Vascular.Size.Height + 180)
                    Me.Size = New Size(grbCerebro_Vascular.Size.Width + 5, grbCerebro_Vascular.Size.Height + 180)

                Case Criterio.Enfermedad_Pulmonar_Cronica
                    grbPulmonar_Cronica.Visible = True
                    grbPulmonar_Cronica.Location = New Point(3, 50)
                    btnGuardar.Location = New Point(710, grbPulmonar_Cronica.Size.Height + 80)
                    pnlCriteioIngreso.Size = New Size(grbPulmonar_Cronica.Size.Width + 5, grbPulmonar_Cronica.Size.Height + 180)
                    Me.Size = New Size(grbPulmonar_Cronica.Size.Width + 5, grbPulmonar_Cronica.Size.Height + 180)

                Case Criterio.Enfermedad_Hepatica_Cronica_Grave
                    grbHepatica_Cronica.Visible = True
                    grbHepatica_Cronica.Location = New Point(3, 50)
                    btnGuardar.Location = New Point(710, grbHepatica_Cronica.Size.Height + 80)
                    pnlCriteioIngreso.Size = New Size(grbHepatica_Cronica.Size.Width + 5, grbHepatica_Cronica.Size.Height + 180)
                    Me.Size = New Size(grbHepatica_Cronica.Size.Width + 5, grbHepatica_Cronica.Size.Height + 180)

                Case Criterio.Enfermedad_Renal_Cronica_Grave
                    grbRenal_Cronica.Visible = True
                    grbRenal_Cronica.Location = New Point(3, 50)
                    btnGuardar.Location = New Point(710, grbRenal_Cronica.Size.Height + 80)
                    pnlCriteioIngreso.Size = New Size(grbRenal_Cronica.Size.Width + 5, grbRenal_Cronica.Size.Height + 180)
                    Me.Size = New Size(grbRenal_Cronica.Size.Width + 5, grbRenal_Cronica.Size.Height + 180)

                Case Criterio.Fragilidad_Severa
                    grbFragilidad_Severa.Visible = True
                    grbFragilidad_Severa.Location = New Point(3, 50)
                    btnGuardar.Location = New Point(710, grbFragilidad_Severa.Size.Height + 80)
                    pnlCriteioIngreso.Size = New Size(grbFragilidad_Severa.Size.Width + 5, grbFragilidad_Severa.Size.Height + 180)
                    Me.Size = New Size(grbFragilidad_Severa.Size.Width + 5, grbFragilidad_Severa.Size.Height + 180)

            End Select
            btnGuardar.Visible = True
            btnSugerirRespuesta.Visible = True

            CriterioIngreso = 0

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Marca las respuestas segun el parametro enviado
    ''' </summary>
    ''' <param name="Respuesta">Valor a marcar</param>
    ''' <remarks></remarks>
    Private Sub MarcarRespuestas(ByVal Respuesta As Boolean)
        Try
            rbtSiOncologica_Diagnostico.Checked = Respuesta
            rbtNoOncologica_Diagnostico.Checked = Respuesta
            rbtSiOncologica_Deterioro.Checked = Respuesta
            rbtNoOncologica_Deterioro.Checked = Respuesta
            rbtSiOncologica_Sintomas.Checked = Respuesta
            rbtNoOncologica_Sintomas.Checked = Respuesta
            rbtSiOncologica_Cumple.Checked = Respuesta
            rbtNoOncologica_Cumple.Checked = Respuesta
            rbtSiVIHSIDA_Criterio.Checked = Respuesta
            rbtNoVIHSIDA_Criterio.Checked = Respuesta
            rbtSiVIHSIDA_Aprobado.Checked = Respuesta
            rbtNoVIHSIDA_Aprobado.Checked = Respuesta
            rbtSiVIHSIDA_Cumple.Checked = Respuesta
            rbtNoVIHSIDA_Cumple.Checked = Respuesta
            rbtSiDemencia_Incapacidad_Vestirse.Checked = Respuesta
            rbtNoDemencia_Incapacidad_Vestirse.Checked = Respuesta
            rbtSiDemencia_Aparicion_Incontinencia.Checked = Respuesta
            rbtNoDemencia_Aparicion_Incontinencia.Checked = Respuesta
            rbtSiDemencia_Incapacidad_Hablar.Checked = Respuesta
            rbtNoDemencia_Incapacidad_Hablar.Checked = Respuesta
            rbtSiDemencia_Perdida.Checked = Respuesta
            rbtNoDemencia_Perdida.Checked = Respuesta
            rbtSiDemencia_Aparicion_Dificultad.Checked = Respuesta
            rbtNoDemencia_Aparicion_Dificultad.Checked = Respuesta
            rbtSiDemencia_Multiples.Checked = Respuesta
            rbtNoDemencia_Multiples.Checked = Respuesta
            rbtSiCumple_Demencia.Checked = Respuesta
            rbtNoCumple_Demencia.Checked = Respuesta
            rbtSiParkinson_Deterioro.Checked = Respuesta
            rbtNoParkinson_Deterioro.Checked = Respuesta
            rbtSiParkinson_Sintomas.Checked = Respuesta
            rbtNoParkinson_Sintomas.Checked = Respuesta
            rbtSiParkinson_Problemas.Checked = Respuesta
            rbtNoParkinson_Problemas.Checked = Respuesta
            rbtSiParkinson_Disfagia.Checked = Respuesta
            rbtNoParkinson_Disfagia.Checked = Respuesta
            rbtSiParkinson_Neumonia.Checked = Respuesta
            rbtNoParkinson_Neumonia.Checked = Respuesta
            rbtSiParkinson_Cumple.Checked = Respuesta
            rbtNoParkinson_Cumple.Checked = Respuesta
            rbtSiMotoneurona_Deterioro.Checked = Respuesta
            rbtNoMotoneurona_Deterioro.Checked = Respuesta
            rbtSiMotoneurona_Sintomas.Checked = Respuesta
            rbtNoMotoneurona_Sintomas.Checked = Respuesta
            rbtSiMotoneurona_Problemas.Checked = Respuesta
            rbtNoMotoneurona_Problemas.Checked = Respuesta
            rbtSiMotoneurona_Disfagia.Checked = Respuesta
            rbtNoMotoneurona_Disfagia.Checked = Respuesta
            rbtSiMotoneurona_Neumonia.Checked = Respuesta
            rbtNoMotoneurona_Neumonia.Checked = Respuesta
            rbtSiMotoneurona_Cumple.Checked = Respuesta
            rbtNoMotoneurona_Cumple.Checked = Respuesta
            rbtSiEsclerosis_Multiple_Deterioro.Checked = Respuesta
            rbtNoEsclerosis_Multiple_Deterioro.Checked = Respuesta
            rbtSiEsclerosis_Multiple_Sintomas.Checked = Respuesta
            rbtNoEsclerosis_Multiple_Sintomas.Checked = Respuesta
            rbtSiEsclerosis_Multiple_Problemas.Checked = Respuesta
            rbtNoEsclerosis_Multiple_Problemas.Checked = Respuesta
            rbtSiEsclerosis_Multiple_Disfagia.Checked = Respuesta
            rbtNoEsclerosis_Multiple_Disfagia.Checked = Respuesta
            rbtSiEsclerosis_Multiple_Neumonia.Checked = Respuesta
            rbtNoEsclerosis_Multiple_Neumonia.Checked = Respuesta
            rbtSiEsclerosis_Multiple_Cumple.Checked = Respuesta
            rbtNoEsclerosis_Multiple_Cumple.Checked = Respuesta
            rbtSiCardiaca_Cronica_Insuficiencia_Cardiaca.Checked = Respuesta
            rbtNoCardiaca_Cronica_Insuficiencia_Cardiaca.Checked = Respuesta
            rbtSiCardiaca_Cronica_Disnea.Checked = Respuesta
            rbtNoCardiaca_Cronica_Disnea.Checked = Respuesta
            rbtSiCardiaca_Cronica_Sintomas.Checked = Respuesta
            rbtNoCardiaca_Cronica_Sintomas.Checked = Respuesta
            rbtSiCardiaca_Cronica_Ecocardiograma.Checked = Respuesta
            rbtNoCardiaca_Cronica_Ecocardiograma.Checked = Respuesta
            rbtSiCardiaca_Cronica_Insuficiencia_Renal.Checked = Respuesta
            rbtNoCardiaca_Cronica_Insuficiencia_Renal.Checked = Respuesta
            rbtSiCardiaca_Cronica_Ingresos.Checked = Respuesta
            rbtNoCardiaca_Cronica_Ingresos.Checked = Respuesta
            rbtSiCardiaca_Cronica_Cumple.Checked = Respuesta
            rbtNoCardiaca_Cronica_Cumple.Checked = Respuesta
            rbtSiCerebro_Vascular_Cumple_Fragilidad.Checked = Respuesta
            rbtNoCerebro_Vascular_Cumple_Fragilidad.Checked = Respuesta
            rbtSiCerebro_Vascular_Aprobado.Checked = Respuesta
            rbtNoCerebro_Vascular_Aprobado.Checked = Respuesta
            rbtSiCerebro_Vascular_Cumple.Checked = Respuesta
            rbtNoCerebro_Vascular_Cumple.Checked = Respuesta
            rbtSiPulmonar_Cronica_Disnea.Checked = Respuesta
            rbtNoPulmonar_Cronica_Disnea.Checked = Respuesta
            rbtSiPulmonar_Cronica_Sintomas.Checked = Respuesta
            rbtNoPulmonar_Cronica_Sintomas.Checked = Respuesta
            rbtSiPulmonar_Cronica_Criterios.Checked = Respuesta  ''WACHV, 04OCT2017, VA LAS RESPUESTA DE LA PREGUNTA Criterios de oxigenoterapia domiciliaria permanente
            rbtNoPulmonar_Cronica_Criterios.Checked = Respuesta  ''WACHV, 04OCT2017, VA LAS RESPUESTA DE LA PREGUNTA Criterios de oxigenoterapia domiciliaria permanente
            rbtSiPulmonar_Cronica_En.Checked = Respuesta   ''WACHV, 04OCT2017, VA LAS RESPUESTA DE LA PREGUNTA En caso de disponer de pruebas funcionales .....
            rbtNoPulmonar_Cronica_En.Checked = Respuesta   ''WACHV, 04OCT2017, VA LAS RESPUESTA DE LA PREGUNTA En caso de disponer de pruebas funcionales .....
            rbtSiPulmonar_Cronica_Insuficiencia.Checked = Respuesta
            rbtNoPulmonar_Cronica_Insuficiencia.Checked = Respuesta
            rbtSiPulmonar_Cronica_Ingresos.Checked = Respuesta
            rbtNoPulmonar_Cronica_Ingresos.Checked = Respuesta
            rbtSiPulmonar_Cronica_Cumple.Checked = Respuesta
            rbtNoPulmonar_Cronica_Cumple.Checked = Respuesta
            rbtSiHepatica_Cronica_Cirrosis.Checked = Respuesta
            rbtNoHepatica_Cronica_Cirrosis.Checked = Respuesta
            rbtSiHepatica_Cronica_Puntuacion.Checked = Respuesta
            rbtNoHepatica_Cronica_Puntuacion.Checked = Respuesta
            rbtSiHepatica_Cronica_Presencia.Checked = Respuesta
            rbtNoHepatica_Cronica_Presencia.Checked = Respuesta
            rbtSiHepatica_Cronica_Carcinoma.Checked = Respuesta
            rbtNoHepatica_Cronica_Carcinoma.Checked = Respuesta
            rbtSiHepatica_Cronica_Cumple.Checked = Respuesta
            rbtNoHepatica_Cronica_Cumple.Checked = Respuesta
            rbtSiRenal_Cronica_Insuficiencia.Checked = Respuesta
            rbtNoRenal_Cronica_Insuficiencia.Checked = Respuesta
            rbtSiRenal_Cronica_CriterioFragilidadSevera.Checked = Respuesta  '''WACHV,20SEPT2017
            rbtNoRenal_Cronica_CriterioFragilidadSevera.Checked = Respuesta  '''WACHV,20SEPT2017
            rbtSiRenal_Cronica_AprobadoJuntaPaliativa.Checked = Respuesta    '''WACHV,20SEPT2017
            rbtNoRenal_Cronica_AprobadoJuntaPaliativa.Checked = Respuesta    '''WACHV,20SEPT2017
            rbtSiRenal_Cronica_Cumple.Checked = Respuesta
            rbtNoRenal_Cronica_Cumple.Checked = Respuesta
            rbtSiFragilidad_Severa_Deterioro.Checked = Respuesta
            rbtNoFragilidad_Severa_Deterioro.Checked = Respuesta
            rbtSiFragilidad_Severa_Perdida_Peso.Checked = Respuesta
            rbtNoFragilidad_Severa_Perdida_Peso.Checked = Respuesta
            rbtSiFragilidad_Severa_Albumina.Checked = Respuesta
            rbtNoFragilidad_Severa_Albumina.Checked = Respuesta
            rbtSDFragilidad_Severa_Albumina.Checked = Respuesta
            rbtSiFragilidad_Severa_Impresion.Checked = Respuesta
            rbtNoFragilidad_Severa_Impresion.Checked = Respuesta
            rbtSiFragilidad_Severa_Barthel.Checked = Respuesta
            rbtNoFragilidad_Severa_Barthel.Checked = Respuesta
            rbtSiFragilidad_Severa_Pps.Checked = Respuesta
            rbtNoFragilidad_Severa_Pps.Checked = Respuesta
            rbtSiFragilidad_Severa_Perdida_Actividades.Checked = Respuesta
            rbtNoFragilidad_Severa_Perdida_Actividades.Checked = Respuesta
            rbtSiFragilidad_Severa_Ulceras.Checked = Respuesta
            rbtNoFragilidad_Severa_Ulceras.Checked = Respuesta
            rbtSiFragilidad_Severa_Infecciones.Checked = Respuesta
            rbtNoFragilidad_Severa_Infecciones.Checked = Respuesta
            rbtSiFragilidad_Severa_Delirium.Checked = Respuesta
            rbtNoFragilidad_Severa_Delirium.Checked = Respuesta
            rbtSiFragilidad_Severa_Disfagia.Checked = Respuesta
            rbtNoFragilidad_Severa_Disfagia.Checked = Respuesta
            rbtSiFragilidad_Severa_Caidas.Checked = Respuesta
            rbtNoFragilidad_Severa_Caidas.Checked = Respuesta
            rbtSiFragilidad_Severa_Sintomas.Checked = Respuesta
            rbtNoFragilidad_Severa_Sintomas.Checked = Respuesta
            rbtSiFragilidad_Severa_Mas_Ingresos.Checked = Respuesta
            rbtNoFragilidad_Severa_Mas_Ingresos.Checked = Respuesta
            rbtSiFragilidad_Severa_Necesidad.Checked = Respuesta
            rbtNoFragilidad_Severa_Necesidad.Checked = Respuesta
            rbtSiFragilidad_Severa_Mas_Patologias.Checked = Respuesta
            rbtNoFragilidad_Severa_Mas_Patologias.Checked = Respuesta
            rbtSiFragilidad_Severa_Cumple.Checked = Respuesta
            rbtNoFragilidad_Severa_Cumple.Checked = Respuesta

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Carga los valores recibidos en el objeto criterio
    ''' </summary>
    ''' <param name="oCriterioIngreso">Objeto que cnotiene las respuetas</param>
    ''' <remarks></remarks>
    Private Sub loadCriterioIngreso(ByVal oCriterioIngreso As CriterioIngreso)
        Try
            If oCriterioIngreso.Oncologica_Diagnostico = 0 Then
                rbtSiOncologica_Diagnostico.Checked = False
                rbtNoOncologica_Diagnostico.Checked = False
            Else
                Select Case oCriterioIngreso.Oncologica_Diagnostico.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiOncologica_Diagnostico.Checked = True
                        rbtNoOncologica_Diagnostico.Checked = False
                    Case "2"
                        rbtSiOncologica_Diagnostico.Checked = False
                        rbtNoOncologica_Diagnostico.Checked = True
                End Select
            End If

            If oCriterioIngreso.Oncologica_Deterioro = 0 Then
                rbtSiOncologica_Deterioro.Checked = False
                rbtNoOncologica_Deterioro.Checked = False
            Else
                Select Case oCriterioIngreso.Oncologica_Deterioro.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiOncologica_Deterioro.Checked = True
                        rbtNoOncologica_Deterioro.Checked = False
                    Case "2"
                        rbtSiOncologica_Deterioro.Checked = False
                        rbtNoOncologica_Deterioro.Checked = True
                End Select
            End If

            If oCriterioIngreso.Oncologica_Sintomas = 0 Then
                rbtSiOncologica_Sintomas.Checked = False
                rbtNoOncologica_Sintomas.Checked = False
            Else
                Select Case oCriterioIngreso.Oncologica_Sintomas.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiOncologica_Sintomas.Checked = True
                        rbtNoOncologica_Sintomas.Checked = False
                    Case "2"
                        rbtSiOncologica_Sintomas.Checked = False
                        rbtNoOncologica_Sintomas.Checked = True
                End Select
            End If

            If oCriterioIngreso.VIHSIDA_Criterio = 0 Then
                rbtSiVIHSIDA_Criterio.Checked = False
                rbtNoVIHSIDA_Criterio.Checked = False
            Else
                Select Case oCriterioIngreso.VIHSIDA_Criterio.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiVIHSIDA_Criterio.Checked = True
                        rbtNoVIHSIDA_Criterio.Checked = False
                    Case "2"
                        rbtSiVIHSIDA_Criterio.Checked = False
                        rbtNoVIHSIDA_Criterio.Checked = True
                End Select
            End If

            If oCriterioIngreso.VIHSIDA_Aprobado = 0 Then
                rbtSiVIHSIDA_Aprobado.Checked = False
                rbtNoVIHSIDA_Aprobado.Checked = False
            Else
                Select Case oCriterioIngreso.VIHSIDA_Aprobado.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiVIHSIDA_Aprobado.Checked = True
                        rbtNoVIHSIDA_Aprobado.Checked = False
                    Case "2"
                        rbtSiVIHSIDA_Aprobado.Checked = False
                        rbtNoVIHSIDA_Aprobado.Checked = True
                End Select
            End If

            If oCriterioIngreso.Demencia_Incapacidad_Vestirse = 0 Then
                rbtSiDemencia_Incapacidad_Vestirse.Checked = False
                rbtNoDemencia_Incapacidad_Vestirse.Checked = False
            Else
                Select Case oCriterioIngreso.Demencia_Incapacidad_Vestirse.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiDemencia_Incapacidad_Vestirse.Checked = True
                        rbtNoDemencia_Incapacidad_Vestirse.Checked = False
                    Case "2"
                        rbtSiDemencia_Incapacidad_Vestirse.Checked = False
                        rbtNoDemencia_Incapacidad_Vestirse.Checked = True
                End Select
            End If

            If oCriterioIngreso.Demencia_Aparicion_Incontinencia = 0 Then
                rbtSiDemencia_Aparicion_Incontinencia.Checked = False
                rbtNoDemencia_Aparicion_Incontinencia.Checked = False
            Else
                Select Case oCriterioIngreso.Demencia_Aparicion_Incontinencia.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiDemencia_Aparicion_Incontinencia.Checked = True
                        rbtNoDemencia_Aparicion_Incontinencia.Checked = False
                    Case "2"
                        rbtSiDemencia_Aparicion_Incontinencia.Checked = False
                        rbtNoDemencia_Aparicion_Incontinencia.Checked = True
                End Select
            End If

            If oCriterioIngreso.Demencia_Incapacidad_Hablar = 0 Then
                rbtSiDemencia_Incapacidad_Hablar.Checked = False
                rbtNoDemencia_Incapacidad_Hablar.Checked = False
            Else
                Select Case oCriterioIngreso.Demencia_Incapacidad_Hablar.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiDemencia_Incapacidad_Hablar.Checked = True
                        rbtNoDemencia_Incapacidad_Hablar.Checked = False
                    Case "2"
                        rbtSiDemencia_Incapacidad_Hablar.Checked = False
                        rbtNoDemencia_Incapacidad_Hablar.Checked = True
                End Select
            End If

            If oCriterioIngreso.Demencia_Perdida = 0 Then
                rbtSiDemencia_Perdida.Checked = False
                rbtNoDemencia_Perdida.Checked = False
            Else
                Select Case oCriterioIngreso.Demencia_Perdida.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiDemencia_Perdida.Checked = True
                        rbtNoDemencia_Perdida.Checked = False
                    Case "2"
                        rbtSiDemencia_Perdida.Checked = False
                        rbtNoDemencia_Perdida.Checked = True
                End Select
            End If

            If oCriterioIngreso.Demencia_Aparicion_Dificultad = 0 Then
                rbtSiDemencia_Aparicion_Dificultad.Checked = False
                rbtNoDemencia_Aparicion_Dificultad.Checked = False
            Else
                Select Case oCriterioIngreso.Demencia_Aparicion_Dificultad.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiDemencia_Aparicion_Dificultad.Checked = True
                        rbtNoDemencia_Aparicion_Dificultad.Checked = False
                    Case "2"
                        rbtSiDemencia_Aparicion_Dificultad.Checked = False
                        rbtNoDemencia_Aparicion_Dificultad.Checked = True
                End Select
            End If

            If oCriterioIngreso.Demencia_Multiples = 0 Then
                rbtSiDemencia_Multiples.Checked = False
                rbtNoDemencia_Multiples.Checked = False
            Else
                Select Case oCriterioIngreso.Demencia_Multiples.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiDemencia_Multiples.Checked = True
                        rbtNoDemencia_Multiples.Checked = False
                    Case "2"
                        rbtSiDemencia_Multiples.Checked = False
                        rbtNoDemencia_Multiples.Checked = True
                End Select
            End If

            If oCriterioIngreso.Parkinson_Deterioro = 0 Then
                rbtSiParkinson_Deterioro.Checked = False
                rbtNoParkinson_Deterioro.Checked = False
            Else
                Select Case oCriterioIngreso.Parkinson_Deterioro.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiParkinson_Deterioro.Checked = True
                        rbtNoParkinson_Deterioro.Checked = False
                    Case "2"
                        rbtSiParkinson_Deterioro.Checked = False
                        rbtNoParkinson_Deterioro.Checked = True
                End Select
            End If

            If oCriterioIngreso.Parkinson_Sintomas = 0 Then
                rbtSiParkinson_Sintomas.Checked = False
                rbtNoParkinson_Sintomas.Checked = False
            Else
                Select Case oCriterioIngreso.Parkinson_Sintomas.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiParkinson_Sintomas.Checked = True
                        rbtNoParkinson_Sintomas.Checked = False
                    Case "2"
                        rbtSiParkinson_Sintomas.Checked = False
                        rbtNoParkinson_Sintomas.Checked = True
                End Select
            End If

            If oCriterioIngreso.Parkinson_Problemas = 0 Then
                rbtSiParkinson_Problemas.Checked = False
                rbtNoParkinson_Problemas.Checked = False
            Else
                Select Case oCriterioIngreso.Parkinson_Problemas.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiParkinson_Problemas.Checked = True
                        rbtNoParkinson_Problemas.Checked = False
                    Case "2"
                        rbtSiParkinson_Problemas.Checked = False
                        rbtNoParkinson_Problemas.Checked = True
                End Select
            End If

            If oCriterioIngreso.Parkinson_Disfagia = 0 Then
                rbtSiParkinson_Disfagia.Checked = False
                rbtNoParkinson_Disfagia.Checked = False
            Else
                Select Case oCriterioIngreso.Parkinson_Disfagia.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiParkinson_Disfagia.Checked = True
                        rbtNoParkinson_Disfagia.Checked = False
                    Case "2"
                        rbtSiParkinson_Disfagia.Checked = False
                        rbtNoParkinson_Disfagia.Checked = True
                End Select
            End If

            If oCriterioIngreso.Parkinson_Neumonia = 0 Then
                rbtSiParkinson_Neumonia.Checked = False
                rbtNoParkinson_Neumonia.Checked = False
            Else
                Select Case oCriterioIngreso.Parkinson_Neumonia.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiParkinson_Neumonia.Checked = True
                        rbtNoParkinson_Neumonia.Checked = False
                    Case "2"
                        rbtSiParkinson_Neumonia.Checked = False
                        rbtNoParkinson_Neumonia.Checked = True
                End Select
            End If

            If oCriterioIngreso.Motoneurona_Deterioro = 0 Then
                rbtSiMotoneurona_Deterioro.Checked = False
                rbtNoMotoneurona_Deterioro.Checked = False
            Else
                Select Case oCriterioIngreso.Motoneurona_Deterioro.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiMotoneurona_Deterioro.Checked = True
                        rbtNoMotoneurona_Deterioro.Checked = False
                    Case "2"
                        rbtSiMotoneurona_Deterioro.Checked = False
                        rbtNoMotoneurona_Deterioro.Checked = True
                End Select
            End If

            If oCriterioIngreso.Motoneurona_Sintomas = 0 Then
                rbtSiMotoneurona_Sintomas.Checked = False
                rbtNoMotoneurona_Sintomas.Checked = False
            Else
                Select Case oCriterioIngreso.Motoneurona_Sintomas.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiMotoneurona_Sintomas.Checked = True
                        rbtNoMotoneurona_Sintomas.Checked = False
                    Case "2"
                        rbtSiMotoneurona_Sintomas.Checked = False
                        rbtNoMotoneurona_Sintomas.Checked = True
                End Select
            End If

            If oCriterioIngreso.Motoneurona_Problemas = 0 Then
                rbtSiMotoneurona_Problemas.Checked = False
                rbtNoMotoneurona_Problemas.Checked = False
            Else
                Select Case oCriterioIngreso.Motoneurona_Problemas.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiMotoneurona_Problemas.Checked = True
                        rbtNoMotoneurona_Problemas.Checked = False
                    Case "2"
                        rbtSiMotoneurona_Problemas.Checked = False
                        rbtNoMotoneurona_Problemas.Checked = True
                End Select
            End If

            If oCriterioIngreso.Motoneurona_Disfagia = 0 Then
                rbtSiMotoneurona_Disfagia.Checked = False
                rbtNoMotoneurona_Disfagia.Checked = False
            Else
                Select Case oCriterioIngreso.Motoneurona_Disfagia.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiMotoneurona_Disfagia.Checked = True
                        rbtNoMotoneurona_Disfagia.Checked = False
                    Case "2"
                        rbtSiMotoneurona_Disfagia.Checked = False
                        rbtNoMotoneurona_Disfagia.Checked = True
                End Select
            End If

            If oCriterioIngreso.Motoneurona_Neumonia = 0 Then
                rbtSiMotoneurona_Neumonia.Checked = False
                rbtNoMotoneurona_Neumonia.Checked = False
            Else
                Select Case oCriterioIngreso.Motoneurona_Neumonia.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiMotoneurona_Neumonia.Checked = True
                        rbtNoMotoneurona_Neumonia.Checked = False
                    Case "2"
                        rbtSiMotoneurona_Neumonia.Checked = False
                        rbtNoMotoneurona_Neumonia.Checked = True
                End Select
            End If

            If oCriterioIngreso.Esclerosis_Multiple_Deterioro = 0 Then
                rbtSiEsclerosis_Multiple_Deterioro.Checked = False
                rbtNoEsclerosis_Multiple_Deterioro.Checked = False
            Else
                Select Case oCriterioIngreso.Esclerosis_Multiple_Deterioro.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiEsclerosis_Multiple_Deterioro.Checked = True
                        rbtNoEsclerosis_Multiple_Deterioro.Checked = False
                    Case "2"
                        rbtSiEsclerosis_Multiple_Deterioro.Checked = False
                        rbtNoEsclerosis_Multiple_Deterioro.Checked = True
                End Select
            End If

            If oCriterioIngreso.Esclerosis_Multiple_Sintomas = 0 Then
                rbtSiEsclerosis_Multiple_Sintomas.Checked = False
                rbtNoEsclerosis_Multiple_Sintomas.Checked = False
            Else
                Select Case oCriterioIngreso.Esclerosis_Multiple_Sintomas.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiEsclerosis_Multiple_Sintomas.Checked = True
                        rbtNoEsclerosis_Multiple_Sintomas.Checked = False
                    Case "2"
                        rbtSiEsclerosis_Multiple_Sintomas.Checked = False
                        rbtNoEsclerosis_Multiple_Sintomas.Checked = True
                End Select
            End If

            If oCriterioIngreso.Esclerosis_Multiple_Problemas = 0 Then
                rbtSiEsclerosis_Multiple_Problemas.Checked = False
                rbtNoEsclerosis_Multiple_Problemas.Checked = False
            Else
                Select Case oCriterioIngreso.Esclerosis_Multiple_Problemas.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiEsclerosis_Multiple_Problemas.Checked = True
                        rbtNoEsclerosis_Multiple_Problemas.Checked = False
                    Case "2"
                        rbtSiEsclerosis_Multiple_Problemas.Checked = False
                        rbtNoEsclerosis_Multiple_Problemas.Checked = True
                End Select
            End If

            If oCriterioIngreso.Esclerosis_Multiple_Disfagia = 0 Then
                rbtSiEsclerosis_Multiple_Disfagia.Checked = False
                rbtNoEsclerosis_Multiple_Disfagia.Checked = False
            Else
                Select Case oCriterioIngreso.Esclerosis_Multiple_Disfagia.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiEsclerosis_Multiple_Disfagia.Checked = True
                        rbtNoEsclerosis_Multiple_Disfagia.Checked = False
                    Case "2"
                        rbtSiEsclerosis_Multiple_Disfagia.Checked = False
                        rbtNoEsclerosis_Multiple_Disfagia.Checked = True
                End Select
            End If

            If oCriterioIngreso.Esclerosis_Multiple_Neumonia = 0 Then
                rbtSiEsclerosis_Multiple_Neumonia.Checked = False
                rbtNoEsclerosis_Multiple_Neumonia.Checked = False
            Else
                Select Case oCriterioIngreso.Esclerosis_Multiple_Neumonia.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiEsclerosis_Multiple_Neumonia.Checked = True
                        rbtNoEsclerosis_Multiple_Neumonia.Checked = False
                    Case "2"
                        rbtSiEsclerosis_Multiple_Neumonia.Checked = False
                        rbtNoEsclerosis_Multiple_Neumonia.Checked = True
                End Select
            End If

            If oCriterioIngreso.Cardiaca_Cronica_Insuficiencia_Cardiaca = 0 Then
                rbtSiCardiaca_Cronica_Insuficiencia_Cardiaca.Checked = False
                rbtNoCardiaca_Cronica_Insuficiencia_Cardiaca.Checked = False
            Else
                Select Case oCriterioIngreso.Cardiaca_Cronica_Insuficiencia_Cardiaca.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiCardiaca_Cronica_Insuficiencia_Cardiaca.Checked = True
                        rbtNoCardiaca_Cronica_Insuficiencia_Cardiaca.Checked = False
                    Case "2"
                        rbtSiCardiaca_Cronica_Insuficiencia_Cardiaca.Checked = False
                        rbtNoCardiaca_Cronica_Insuficiencia_Cardiaca.Checked = True
                End Select
            End If

            If oCriterioIngreso.Cardiaca_Cronica_Disnea = 0 Then
                rbtSiCardiaca_Cronica_Disnea.Checked = False
                rbtNoCardiaca_Cronica_Disnea.Checked = False
            Else
                Select Case oCriterioIngreso.Cardiaca_Cronica_Disnea.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiCardiaca_Cronica_Disnea.Checked = True
                        rbtNoCardiaca_Cronica_Disnea.Checked = False
                    Case "2"
                        rbtSiCardiaca_Cronica_Disnea.Checked = False
                        rbtNoCardiaca_Cronica_Disnea.Checked = True
                End Select
            End If

            If oCriterioIngreso.Cardiaca_Cronica_Sintomas = 0 Then
                rbtSiCardiaca_Cronica_Sintomas.Checked = False
                rbtNoCardiaca_Cronica_Sintomas.Checked = False
            Else
                Select Case oCriterioIngreso.Cardiaca_Cronica_Sintomas.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiCardiaca_Cronica_Sintomas.Checked = True
                        rbtNoCardiaca_Cronica_Sintomas.Checked = False
                    Case "2"
                        rbtSiCardiaca_Cronica_Sintomas.Checked = False
                        rbtNoCardiaca_Cronica_Sintomas.Checked = True
                End Select
            End If

            If oCriterioIngreso.Cardiaca_Cronica_Ecocardiograma = 0 Then
                rbtSiCardiaca_Cronica_Ecocardiograma.Checked = False
                rbtNoCardiaca_Cronica_Ecocardiograma.Checked = False
            Else
                Select Case oCriterioIngreso.Cardiaca_Cronica_Ecocardiograma.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiCardiaca_Cronica_Ecocardiograma.Checked = True
                        rbtNoCardiaca_Cronica_Ecocardiograma.Checked = False
                    Case "2"
                        rbtSiCardiaca_Cronica_Ecocardiograma.Checked = False
                        rbtNoCardiaca_Cronica_Ecocardiograma.Checked = True
                End Select
            End If

            If oCriterioIngreso.Cardiaca_Cronica_Insuficiencia_Renal = 0 Then
                rbtSiCardiaca_Cronica_Insuficiencia_Renal.Checked = False
                rbtNoCardiaca_Cronica_Insuficiencia_Renal.Checked = False
            Else
                Select Case oCriterioIngreso.Cardiaca_Cronica_Insuficiencia_Renal.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiCardiaca_Cronica_Insuficiencia_Renal.Checked = True
                        rbtNoCardiaca_Cronica_Insuficiencia_Renal.Checked = False
                    Case "2"
                        rbtSiCardiaca_Cronica_Insuficiencia_Renal.Checked = False
                        rbtNoCardiaca_Cronica_Insuficiencia_Renal.Checked = True
                End Select
            End If

            If oCriterioIngreso.Cardiaca_Cronica_Ingresos = 0 Then
                rbtSiCardiaca_Cronica_Ingresos.Checked = False
                rbtNoCardiaca_Cronica_Ingresos.Checked = False
            Else
                Select Case oCriterioIngreso.Cardiaca_Cronica_Ingresos.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiCardiaca_Cronica_Ingresos.Checked = True
                        rbtNoCardiaca_Cronica_Ingresos.Checked = False
                    Case "2"
                        rbtSiCardiaca_Cronica_Ingresos.Checked = False
                        rbtNoCardiaca_Cronica_Ingresos.Checked = True
                End Select
            End If

            If oCriterioIngreso.Cerebro_Vascular_Cumple_Fragilidad = 0 Then
                rbtSiCerebro_Vascular_Cumple_Fragilidad.Checked = False
                rbtNoCerebro_Vascular_Cumple_Fragilidad.Checked = False
            Else
                Select Case oCriterioIngreso.Cerebro_Vascular_Cumple_Fragilidad.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiCerebro_Vascular_Cumple_Fragilidad.Checked = True
                        rbtNoCerebro_Vascular_Cumple_Fragilidad.Checked = False
                    Case "2"
                        rbtSiCerebro_Vascular_Cumple_Fragilidad.Checked = False
                        rbtNoCerebro_Vascular_Cumple_Fragilidad.Checked = True
                End Select
            End If

            If oCriterioIngreso.Cerebro_Vascular_Aprobado = 0 Then
                rbtSiCerebro_Vascular_Aprobado.Checked = False
                rbtNoCerebro_Vascular_Aprobado.Checked = False
            Else
                Select Case oCriterioIngreso.Cerebro_Vascular_Aprobado.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiCerebro_Vascular_Aprobado.Checked = True
                        rbtNoCerebro_Vascular_Aprobado.Checked = False
                    Case "2"
                        rbtSiCerebro_Vascular_Aprobado.Checked = False
                        rbtNoCerebro_Vascular_Aprobado.Checked = True
                End Select
            End If

            If oCriterioIngreso.Pulmonar_Cronica_Disnea = 0 Then
                rbtSiPulmonar_Cronica_Disnea.Checked = False
                rbtNoPulmonar_Cronica_Disnea.Checked = False
            Else
                Select Case oCriterioIngreso.Pulmonar_Cronica_Disnea.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiPulmonar_Cronica_Disnea.Checked = True
                        rbtNoPulmonar_Cronica_Disnea.Checked = False
                    Case "2"
                        rbtSiPulmonar_Cronica_Disnea.Checked = False
                        rbtNoPulmonar_Cronica_Disnea.Checked = True
                End Select
            End If

            If oCriterioIngreso.Pulmonar_Cronica_Sintomas = 0 Then
                rbtSiPulmonar_Cronica_Sintomas.Checked = False
                rbtNoPulmonar_Cronica_Sintomas.Checked = False
            Else
                Select Case oCriterioIngreso.Pulmonar_Cronica_Sintomas.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiPulmonar_Cronica_Sintomas.Checked = True
                        rbtNoPulmonar_Cronica_Sintomas.Checked = False
                    Case "2"
                        rbtSiPulmonar_Cronica_Sintomas.Checked = False
                        rbtNoPulmonar_Cronica_Sintomas.Checked = True
                End Select
            End If

            If oCriterioIngreso.Pulmonar_Cronica_Criterios = 0 Then
                rbtSiPulmonar_Cronica_Criterios.Checked = False
                rbtNoPulmonar_Cronica_Criterios.Checked = False
            Else
                Select Case oCriterioIngreso.Pulmonar_Cronica_Criterios.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiPulmonar_Cronica_Criterios.Checked = True
                        rbtNoPulmonar_Cronica_Criterios.Checked = False
                    Case "2"
                        rbtSiPulmonar_Cronica_Criterios.Checked = False
                        rbtNoPulmonar_Cronica_Criterios.Checked = True
                End Select
            End If

            If oCriterioIngreso.Pulmonar_Cronica_En = 0 Then
                rbtSiPulmonar_Cronica_En.Checked = False
                rbtNoPulmonar_Cronica_En.Checked = False
            Else
                Select Case oCriterioIngreso.Pulmonar_Cronica_En.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiPulmonar_Cronica_En.Checked = True
                        rbtNoPulmonar_Cronica_En.Checked = False
                    Case "2"
                        rbtSiPulmonar_Cronica_En.Checked = False
                        rbtNoPulmonar_Cronica_En.Checked = True
                End Select
            End If

            If oCriterioIngreso.Pulmonar_Cronica_Insuficiencia = 0 Then
                rbtSiPulmonar_Cronica_Insuficiencia.Checked = False
                rbtNoPulmonar_Cronica_Insuficiencia.Checked = False
            Else
                Select Case oCriterioIngreso.Pulmonar_Cronica_Insuficiencia.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiPulmonar_Cronica_Insuficiencia.Checked = True
                        rbtNoPulmonar_Cronica_Insuficiencia.Checked = False
                    Case "2"
                        rbtSiPulmonar_Cronica_Insuficiencia.Checked = False
                        rbtNoPulmonar_Cronica_Insuficiencia.Checked = True
                End Select
            End If

            If oCriterioIngreso.Pulmonar_Cronica_Ingresos = 0 Then
                rbtSiPulmonar_Cronica_Ingresos.Checked = False
                rbtNoPulmonar_Cronica_Ingresos.Checked = False
            Else
                Select Case oCriterioIngreso.Pulmonar_Cronica_Ingresos.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiPulmonar_Cronica_Ingresos.Checked = True
                        rbtNoPulmonar_Cronica_Ingresos.Checked = False
                    Case "2"
                        rbtSiPulmonar_Cronica_Ingresos.Checked = False
                        rbtNoPulmonar_Cronica_Ingresos.Checked = True
                End Select
            End If

            If oCriterioIngreso.Hepatica_Cronica_Cirrosis = 0 Then
                rbtSiHepatica_Cronica_Cirrosis.Checked = False
                rbtNoHepatica_Cronica_Cirrosis.Checked = False
            Else
                Select Case oCriterioIngreso.Hepatica_Cronica_Cirrosis.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiHepatica_Cronica_Cirrosis.Checked = True
                        rbtNoHepatica_Cronica_Cirrosis.Checked = False
                    Case "2"
                        rbtSiHepatica_Cronica_Cirrosis.Checked = False
                        rbtNoHepatica_Cronica_Cirrosis.Checked = True
                End Select
            End If

            If oCriterioIngreso.Hepatica_Cronica_Puntuacion = 0 Then
                rbtSiHepatica_Cronica_Puntuacion.Checked = False
                rbtNoHepatica_Cronica_Puntuacion.Checked = False
            Else
                Select Case oCriterioIngreso.Hepatica_Cronica_Puntuacion.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiHepatica_Cronica_Puntuacion.Checked = True
                        rbtNoHepatica_Cronica_Puntuacion.Checked = False
                    Case "2"
                        rbtSiHepatica_Cronica_Puntuacion.Checked = False
                        rbtNoHepatica_Cronica_Puntuacion.Checked = True
                End Select
            End If

            If oCriterioIngreso.Hepatica_Cronica_Presencia = 0 Then
                rbtSiHepatica_Cronica_Presencia.Checked = False
                rbtNoHepatica_Cronica_Presencia.Checked = False
            Else
                Select Case oCriterioIngreso.Hepatica_Cronica_Presencia.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiHepatica_Cronica_Presencia.Checked = True
                        rbtNoHepatica_Cronica_Presencia.Checked = False
                    Case "2"
                        rbtSiHepatica_Cronica_Presencia.Checked = False
                        rbtNoHepatica_Cronica_Presencia.Checked = True
                End Select
            End If

            If oCriterioIngreso.Hepatica_Cronica_Carcinoma = 0 Then
                rbtSiHepatica_Cronica_Carcinoma.Checked = False
                rbtNoHepatica_Cronica_Carcinoma.Checked = False
            Else
                Select Case oCriterioIngreso.Hepatica_Cronica_Carcinoma.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiHepatica_Cronica_Carcinoma.Checked = True
                        rbtNoHepatica_Cronica_Carcinoma.Checked = False
                    Case "2"
                        rbtSiHepatica_Cronica_Carcinoma.Checked = False
                        rbtNoHepatica_Cronica_Carcinoma.Checked = True
                End Select
            End If

            If oCriterioIngreso.Renal_Cronica_Insuficiencia = 0 Then
                rbtSiRenal_Cronica_Insuficiencia.Checked = False
                rbtNoRenal_Cronica_Insuficiencia.Checked = False
            Else
                Select Case oCriterioIngreso.Renal_Cronica_Insuficiencia.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiRenal_Cronica_Insuficiencia.Checked = True
                        rbtNoRenal_Cronica_Insuficiencia.Checked = False
                    Case "2"
                        rbtSiRenal_Cronica_Insuficiencia.Checked = False
                        rbtNoRenal_Cronica_Insuficiencia.Checked = True
                End Select
            End If

            ''WACHV,INICIO, 20SEPT2017, PARA LOS NUEVOS VALORES
            If oCriterioIngreso.Renal_Cronica_CriterioFragilidadSevera = 0 Then
                rbtSiRenal_Cronica_CriterioFragilidadSevera.Checked = False
                rbtNoRenal_Cronica_CriterioFragilidadSevera.Checked = False
            Else
                Select Case oCriterioIngreso.Renal_Cronica_CriterioFragilidadSevera.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiRenal_Cronica_CriterioFragilidadSevera.Checked = True
                        rbtNoRenal_Cronica_CriterioFragilidadSevera.Checked = False
                    Case "2"
                        rbtSiRenal_Cronica_CriterioFragilidadSevera.Checked = False
                        rbtNoRenal_Cronica_CriterioFragilidadSevera.Checked = True
                End Select
            End If

            If oCriterioIngreso.Renal_Cronica_AprobadoJuntaPaliativa = 0 Then
                rbtSiRenal_Cronica_AprobadoJuntaPaliativa.Checked = False
                rbtNoRenal_Cronica_AprobadoJuntaPaliativa.Checked = False
            Else
                Select Case oCriterioIngreso.Renal_Cronica_AprobadoJuntaPaliativa.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiRenal_Cronica_AprobadoJuntaPaliativa.Checked = True
                        rbtNoRenal_Cronica_AprobadoJuntaPaliativa.Checked = False
                    Case "2"
                        rbtSiRenal_Cronica_AprobadoJuntaPaliativa.Checked = False
                        rbtNoRenal_Cronica_AprobadoJuntaPaliativa.Checked = True
                End Select
            End If

            ''WACHV,FIN, 20SEPT2017, PARA LOS NUEVOS VALORES

            If oCriterioIngreso.Fragilidad_Severa_Deterioro = 0 Then
                rbtSiFragilidad_Severa_Deterioro.Checked = False
                rbtNoFragilidad_Severa_Deterioro.Checked = False
            Else
                Select Case oCriterioIngreso.Fragilidad_Severa_Deterioro.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiFragilidad_Severa_Deterioro.Checked = True
                        rbtNoFragilidad_Severa_Deterioro.Checked = False
                    Case "2"
                        rbtSiFragilidad_Severa_Deterioro.Checked = False
                        rbtNoFragilidad_Severa_Deterioro.Checked = True
                End Select
            End If

            If oCriterioIngreso.Fragilidad_Severa_Perdida_Peso = 0 Then
                rbtSiFragilidad_Severa_Perdida_Peso.Checked = False
                rbtNoFragilidad_Severa_Perdida_Peso.Checked = False
            Else
                Select Case oCriterioIngreso.Fragilidad_Severa_Perdida_Peso.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiFragilidad_Severa_Perdida_Peso.Checked = True
                        rbtNoFragilidad_Severa_Perdida_Peso.Checked = False
                    Case "2"
                        rbtSiFragilidad_Severa_Perdida_Peso.Checked = False
                        rbtNoFragilidad_Severa_Perdida_Peso.Checked = True
                End Select
            End If

            If oCriterioIngreso.Fragilidad_Severa_Albumina = 0 Then
                rbtSiFragilidad_Severa_Albumina.Checked = False
                rbtNoFragilidad_Severa_Albumina.Checked = False
            Else
                Select Case oCriterioIngreso.Fragilidad_Severa_Albumina.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiFragilidad_Severa_Albumina.Checked = True
                        rbtNoFragilidad_Severa_Albumina.Checked = False
                    Case "2"
                        rbtSiFragilidad_Severa_Albumina.Checked = False
                        rbtNoFragilidad_Severa_Albumina.Checked = True
                End Select
            End If

            If oCriterioIngreso.Fragilidad_Severa_Impresion = 0 Then
                rbtSiFragilidad_Severa_Impresion.Checked = False
                rbtNoFragilidad_Severa_Impresion.Checked = False
            Else
                Select Case oCriterioIngreso.Fragilidad_Severa_Impresion.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiFragilidad_Severa_Impresion.Checked = True
                        rbtNoFragilidad_Severa_Impresion.Checked = False
                    Case "2"
                        rbtSiFragilidad_Severa_Impresion.Checked = False
                        rbtNoFragilidad_Severa_Impresion.Checked = True
                End Select
            End If

            If oCriterioIngreso.Fragilidad_Severa_Barthel = 0 Then
                rbtSiFragilidad_Severa_Barthel.Checked = False
                rbtNoFragilidad_Severa_Barthel.Checked = False
            Else
                Select Case oCriterioIngreso.Fragilidad_Severa_Barthel.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiFragilidad_Severa_Barthel.Checked = True
                        rbtNoFragilidad_Severa_Barthel.Checked = False
                    Case "2"
                        rbtSiFragilidad_Severa_Barthel.Checked = False
                        rbtNoFragilidad_Severa_Barthel.Checked = True
                End Select
            End If

            If oCriterioIngreso.Fragilidad_Severa_Pps = 0 Then
                rbtSiFragilidad_Severa_Pps.Checked = False
                rbtNoFragilidad_Severa_Pps.Checked = False
            Else
                Select Case oCriterioIngreso.Fragilidad_Severa_Pps.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiFragilidad_Severa_Pps.Checked = True
                        rbtNoFragilidad_Severa_Pps.Checked = False
                    Case "2"
                        rbtSiFragilidad_Severa_Pps.Checked = False
                        rbtNoFragilidad_Severa_Pps.Checked = True
                End Select
            End If

            If oCriterioIngreso.Fragilidad_Severa_Perdida_Actividades = 0 Then
                rbtSiFragilidad_Severa_Perdida_Actividades.Checked = False
                rbtNoFragilidad_Severa_Perdida_Actividades.Checked = False
            Else
                Select Case oCriterioIngreso.Fragilidad_Severa_Perdida_Actividades.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiFragilidad_Severa_Perdida_Actividades.Checked = True
                        rbtNoFragilidad_Severa_Perdida_Actividades.Checked = False
                    Case "2"
                        rbtSiFragilidad_Severa_Perdida_Actividades.Checked = False
                        rbtNoFragilidad_Severa_Perdida_Actividades.Checked = True
                End Select
            End If

            If oCriterioIngreso.Fragilidad_Severa_Ulceras = 0 Then
                rbtSiFragilidad_Severa_Ulceras.Checked = False
                rbtNoFragilidad_Severa_Ulceras.Checked = False
            Else
                Select Case oCriterioIngreso.Fragilidad_Severa_Ulceras.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiFragilidad_Severa_Ulceras.Checked = True
                        rbtNoFragilidad_Severa_Ulceras.Checked = False
                    Case "2"
                        rbtSiFragilidad_Severa_Ulceras.Checked = False
                        rbtNoFragilidad_Severa_Ulceras.Checked = True
                End Select
            End If

            If oCriterioIngreso.Fragilidad_Severa_Infecciones = 0 Then
                rbtSiFragilidad_Severa_Infecciones.Checked = False
                rbtNoFragilidad_Severa_Infecciones.Checked = False
            Else
                Select Case oCriterioIngreso.Fragilidad_Severa_Infecciones.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiFragilidad_Severa_Infecciones.Checked = True
                        rbtNoFragilidad_Severa_Infecciones.Checked = False
                    Case "2"
                        rbtSiFragilidad_Severa_Infecciones.Checked = False
                        rbtNoFragilidad_Severa_Infecciones.Checked = True
                End Select
            End If

            If oCriterioIngreso.Fragilidad_Severa_Delirium = 0 Then
                rbtSiFragilidad_Severa_Delirium.Checked = False
                rbtNoFragilidad_Severa_Delirium.Checked = False
            Else
                Select Case oCriterioIngreso.Fragilidad_Severa_Delirium.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiFragilidad_Severa_Delirium.Checked = True
                        rbtNoFragilidad_Severa_Delirium.Checked = False
                    Case "2"
                        rbtSiFragilidad_Severa_Delirium.Checked = False
                        rbtNoFragilidad_Severa_Delirium.Checked = True
                End Select
            End If

            If oCriterioIngreso.Fragilidad_Severa_Disfagia = 0 Then
                rbtSiFragilidad_Severa_Disfagia.Checked = False
                rbtNoFragilidad_Severa_Disfagia.Checked = False
            Else
                Select Case oCriterioIngreso.Fragilidad_Severa_Disfagia.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiFragilidad_Severa_Disfagia.Checked = True
                        rbtNoFragilidad_Severa_Disfagia.Checked = False
                    Case "2"
                        rbtSiFragilidad_Severa_Disfagia.Checked = False
                        rbtNoFragilidad_Severa_Disfagia.Checked = True
                End Select
            End If

            If oCriterioIngreso.Fragilidad_Severa_Caidas = 0 Then
                rbtSiFragilidad_Severa_Caidas.Checked = False
                rbtNoFragilidad_Severa_Caidas.Checked = False
            Else
                Select Case oCriterioIngreso.Fragilidad_Severa_Caidas.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiFragilidad_Severa_Caidas.Checked = True
                        rbtNoFragilidad_Severa_Caidas.Checked = False
                    Case "2"
                        rbtSiFragilidad_Severa_Caidas.Checked = False
                        rbtNoFragilidad_Severa_Caidas.Checked = True
                End Select
            End If

            If oCriterioIngreso.Fragilidad_Severa_Sintomas = 0 Then
                rbtSiFragilidad_Severa_Sintomas.Checked = False
                rbtNoFragilidad_Severa_Sintomas.Checked = False
            Else
                Select Case oCriterioIngreso.Fragilidad_Severa_Sintomas.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiFragilidad_Severa_Sintomas.Checked = True
                        rbtNoFragilidad_Severa_Sintomas.Checked = False
                    Case "2"
                        rbtSiFragilidad_Severa_Sintomas.Checked = False
                        rbtNoFragilidad_Severa_Sintomas.Checked = True
                End Select
            End If

            If oCriterioIngreso.Fragilidad_Severa_Mas_Ingresos = 0 Then
                rbtSiFragilidad_Severa_Mas_Ingresos.Checked = False
                rbtNoFragilidad_Severa_Mas_Ingresos.Checked = False
            Else
                Select Case oCriterioIngreso.Fragilidad_Severa_Mas_Ingresos.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiFragilidad_Severa_Mas_Ingresos.Checked = True
                        rbtNoFragilidad_Severa_Mas_Ingresos.Checked = False
                    Case "2"
                        rbtSiFragilidad_Severa_Mas_Ingresos.Checked = False
                        rbtNoFragilidad_Severa_Mas_Ingresos.Checked = True
                End Select
            End If

            If oCriterioIngreso.Fragilidad_Severa_Necesidad = 0 Then
                rbtSiFragilidad_Severa_Necesidad.Checked = False
                rbtNoFragilidad_Severa_Necesidad.Checked = False
            Else
                Select Case oCriterioIngreso.Fragilidad_Severa_Necesidad.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiFragilidad_Severa_Necesidad.Checked = True
                        rbtNoFragilidad_Severa_Necesidad.Checked = False
                    Case "2"
                        rbtSiFragilidad_Severa_Necesidad.Checked = False
                        rbtNoFragilidad_Severa_Necesidad.Checked = True
                End Select
            End If

            If oCriterioIngreso.Fragilidad_Severa_Mas_Patologias = 0 Then
                rbtSiFragilidad_Severa_Mas_Patologias.Checked = False
                rbtNoFragilidad_Severa_Mas_Patologias.Checked = False
            Else
                Select Case oCriterioIngreso.Fragilidad_Severa_Mas_Patologias.ToString().Substring(4, 1)
                    Case "1"
                        rbtSiFragilidad_Severa_Mas_Patologias.Checked = True
                        rbtNoFragilidad_Severa_Mas_Patologias.Checked = False
                    Case "2"
                        rbtSiFragilidad_Severa_Mas_Patologias.Checked = False
                        rbtNoFragilidad_Severa_Mas_Patologias.Checked = True
                End Select
            End If

        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    ''27Sept2017,WACHV, INICIO, para que los controles radio button queden sin seleccionar x defecto
    Private Sub fnRadioButtonSinMarcar(iCriterioIngreso As Int32)

        Select Case iCriterioIngreso
            Case 1 ''Criterio de Ingreso Enfermedad Oncologica 
                For Each control As Control In grbEnfermedad_Oncologica.Controls
                    If TypeOf (control) Is Panel Then
                        For Each subControl As Control In control.Controls
                            If TypeOf (subControl) Is RadioButton Then
                                CType(subControl, RadioButton).Checked = False
                            End If
                        Next
                    End If
                    If TypeOf (control) Is RadioButton Then
                        CType(control, RadioButton).Checked = False
                    End If
                Next


            Case 2 ''Criterio de Ingreso VIH/SIDA
                For Each control As Control In grbVIHSIDA.Controls
                    If TypeOf (control) Is Panel Then
                        For Each subControl As Control In control.Controls
                            If TypeOf (subControl) Is RadioButton Then
                                CType(subControl, RadioButton).Checked = False
                            End If
                        Next
                    End If
                    If TypeOf (control) Is RadioButton Then
                        CType(control, RadioButton).Checked = False
                    End If
                Next


            Case 3 ''Criterio de ingreso: DEMENCIA

                For Each control As Control In grbDemencia.Controls
                    If TypeOf (control) Is Panel Then
                        For Each subControl As Control In control.Controls
                            If TypeOf (subControl) Is RadioButton Then
                                CType(subControl, RadioButton).Checked = False
                            End If
                        Next
                    End If
                    If TypeOf (control) Is RadioButton Then
                        CType(control, RadioButton).Checked = False
                    End If
                Next


            Case 4 ''Criterio de ingreso: PARKINSON
                For Each control As Control In grbParkinson.Controls
                    If TypeOf (control) Is Panel Then
                        For Each subControl As Control In control.Controls
                            If TypeOf (subControl) Is RadioButton Then
                                CType(subControl, RadioButton).Checked = False
                            End If
                        Next
                    End If
                    If TypeOf (control) Is RadioButton Then
                        CType(control, RadioButton).Checked = False
                    End If
                Next


            Case 5 '''Criterio de ingreso: ELA Y ENFERMEDADES DE MOTONEURONA

                For Each control As Control In grbMotoneurona.Controls
                    If TypeOf (control) Is Panel Then
                        For Each subControl As Control In control.Controls
                            If TypeOf (subControl) Is RadioButton Then
                                CType(subControl, RadioButton).Checked = False
                            End If
                        Next
                    End If
                    If TypeOf (control) Is RadioButton Then
                        CType(control, RadioButton).Checked = False
                    End If
                Next


            Case 6 '''Criterio de ingreso: ESCLEROSIS MÚLTIPLE

                For Each control As Control In grbEsclerosis_Multiple.Controls
                    If TypeOf (control) Is Panel Then
                        For Each subControl As Control In control.Controls
                            If TypeOf (subControl) Is RadioButton Then
                                CType(subControl, RadioButton).Checked = False
                            End If
                        Next
                    End If
                    If TypeOf (control) Is RadioButton Then
                        CType(control, RadioButton).Checked = False
                    End If
                Next


            Case 7 '''Criterio de ingreso: ENFERMEDAD CARDIACA CRÓNICA


                For Each control As Control In grbCardiaca_Cronica.Controls
                    If TypeOf (control) Is Panel Then
                        For Each subControl As Control In control.Controls
                            If TypeOf (subControl) Is RadioButton Then
                                CType(subControl, RadioButton).Checked = False
                            End If
                        Next
                    End If
                Next


            Case 8 ''Criterio de ingreso: EVENTO CEREBROVASCULAR
                For Each control As Control In grbCerebro_Vascular.Controls
                    If TypeOf (control) Is Panel Then
                        For Each subControl As Control In control.Controls
                            If TypeOf (subControl) Is RadioButton Then
                                CType(subControl, RadioButton).Checked = False
                            End If
                        Next
                    End If
                    If TypeOf (control) Is RadioButton Then
                        CType(control, RadioButton).Checked = False
                    End If
                Next


            Case 9 '''Criterio de ingreso: ENFERMEDAD PULMONAR CRÓNICA
                For Each control As Control In grbPulmonar_Cronica.Controls
                    If TypeOf (control) Is Panel Then
                        For Each subControl As Control In control.Controls
                            If TypeOf (subControl) Is RadioButton Then
                                CType(subControl, RadioButton).Checked = False
                            End If
                        Next
                    End If
                    If TypeOf (control) Is RadioButton Then
                        CType(control, RadioButton).Checked = False
                    End If
                Next

            Case 10 '''Criterio de ingreso: ENFERMEDAD HEPÁTICA CRÓNICA GRAVE
                For Each control As Control In grbHepatica_Cronica.Controls
                    If TypeOf (control) Is Panel Then
                        For Each subControl As Control In control.Controls
                            If TypeOf (subControl) Is RadioButton Then
                                CType(subControl, RadioButton).Checked = False
                            End If
                        Next
                    End If
                    If TypeOf (control) Is RadioButton Then
                        CType(control, RadioButton).Checked = False
                    End If
                Next


            Case 11 '''Criterio de ingreso: ENFERMEDAD RENAL CRÓNICA GRAVE
                For Each control As Control In grbRenal_Cronica.Controls
                    If TypeOf (control) Is Panel Then
                        For Each subControl As Control In control.Controls
                            If TypeOf (subControl) Is RadioButton Then
                                CType(subControl, RadioButton).Checked = False
                            End If
                        Next
                    End If
                    If TypeOf (control) Is RadioButton Then
                        CType(control, RadioButton).Checked = False
                    End If
                Next

            Case 12 '''Criterio de ingreso: FRAGILIDAD SEVERA
                For Each control As Control In grbFragilidad_Severa.Controls
                    If TypeOf (control) Is Panel Then
                        For Each subControl As Control In control.Controls
                            If TypeOf (subControl) Is RadioButton Then
                                CType(subControl, RadioButton).Checked = False
                            End If
                        Next
                    End If
                    If TypeOf (control) Is RadioButton Then
                        CType(control, RadioButton).Checked = False
                    End If
                Next

        End Select

    End Sub ''27Sept2017,WACHV, INICIO, para que los controles radio button queden sin seleccionar


    ''' <summary>
    ''' Valida Obligatoriiedad de radio buttons
    ''' </summary>
    ''' <remarks>WACHV, 19SEPT2017</remarks>
    Private Function bfncObligatoriedad(iCriterioIngreso As Int32) As Boolean
        Dim bValidoObligatorio As Boolean = False

        Select Case iCriterioIngreso
            Case 1 ''Criterio de Ingreso Enfermedad Oncologica 
                If rbtSiOncologica_Diagnostico.Checked Or rbtNoOncologica_Diagnostico.Checked Then
                    If rbtSiOncologica_Deterioro.Checked Or rbtNoOncologica_Deterioro.Checked Then
                        If rbtSiOncologica_Sintomas.Checked Or rbtNoOncologica_Sintomas.Checked Then
                            bValidoObligatorio = True
                            ''Si, Si, Si
                            If rbtSiOncologica_Diagnostico.Checked And rbtSiOncologica_Deterioro.Checked And rbtSiOncologica_Sintomas.Checked Then
                                rbtSiOncologica_Cumple.Checked = True
                            End If
                            ''Si, Si, No
                            If rbtSiOncologica_Diagnostico.Checked And rbtSiOncologica_Deterioro.Checked And rbtNoOncologica_Sintomas.Checked Then
                                rbtSiOncologica_Cumple.Checked = True
                            End If
                            ''Si, NO, Si
                            If rbtSiOncologica_Diagnostico.Checked And rbtNoOncologica_Deterioro.Checked And rbtSiOncologica_Sintomas.Checked Then
                                rbtSiOncologica_Cumple.Checked = True
                            End If
                            ''NO, NO, NO
                            If rbtNoOncologica_Diagnostico.Checked And rbtNoOncologica_Deterioro.Checked And rbtNoOncologica_Sintomas.Checked Then
                                rbtNoOncologica_Cumple.Checked = True
                            End If
                            ''NO, Si, Si
                            If rbtNoOncologica_Diagnostico.Checked And rbtSiOncologica_Deterioro.Checked And rbtSiOncologica_Sintomas.Checked Then
                                rbtNoOncologica_Cumple.Checked = True
                            End If
                            ''NO, Si, No
                            If rbtNoOncologica_Diagnostico.Checked And rbtSiOncologica_Deterioro.Checked And rbtNoOncologica_Sintomas.Checked Then
                                rbtNoOncologica_Cumple.Checked = True
                            End If
                            ''NO, No, Si
                            If rbtNoOncologica_Diagnostico.Checked And rbtNoOncologica_Deterioro.Checked And rbtSiOncologica_Sintomas.Checked Then
                                rbtNoOncologica_Cumple.Checked = True
                            End If
                            ''Si, No, No
                            If rbtSiOncologica_Diagnostico.Checked And rbtNoOncologica_Deterioro.Checked And rbtNoOncologica_Sintomas.Checked Then
                                rbtNoOncologica_Cumple.Checked = True
                            End If
                        End If
                    End If
                End If

            Case 2 ''Criterio de Ingreso VIH/SIDA
                If rbtSiVIHSIDA_Criterio.Checked Or rbtNoVIHSIDA_Criterio.Checked Then
                    If rbtSiVIHSIDA_Aprobado.Checked Or rbtNoVIHSIDA_Aprobado.Checked Then
                        bValidoObligatorio = True
                        ''SI,SI
                        If rbtSiVIHSIDA_Criterio.Checked And rbtSiVIHSIDA_Aprobado.Checked Then
                            rbtSiVIHSIDA_Cumple.Checked = True
                        End If
                        ''SI,No
                        If rbtSiVIHSIDA_Criterio.Checked And rbtNoVIHSIDA_Aprobado.Checked Then
                            rbtNoVIHSIDA_Cumple.Checked = True
                        End If
                        ''No,Si
                        If rbtNoVIHSIDA_Criterio.Checked And rbtSiVIHSIDA_Aprobado.Checked Then
                            rbtNoVIHSIDA_Cumple.Checked = True
                        End If
                        ''No,No
                        If rbtNoVIHSIDA_Criterio.Checked And rbtNoVIHSIDA_Aprobado.Checked Then
                            rbtNoVIHSIDA_Cumple.Checked = True
                        End If
                    End If
                End If
            Case 3 ''Criterio de ingreso: DEMENCIA
                If rbtSiDemencia_Incapacidad_Vestirse.Checked Or rbtNoDemencia_Incapacidad_Vestirse.Checked Then
                    If rbtSiDemencia_Aparicion_Incontinencia.Checked Or rbtNoDemencia_Aparicion_Incontinencia.Checked Then
                        If rbtSiDemencia_Incapacidad_Hablar.Checked Or rbtNoDemencia_Incapacidad_Hablar.Checked Then
                            If rbtSiDemencia_Perdida.Checked Or rbtNoDemencia_Perdida.Checked Then
                                If rbtSiDemencia_Aparicion_Dificultad.Checked Or rbtNoDemencia_Aparicion_Dificultad.Checked Then
                                    If rbtSiDemencia_Multiples.Checked Or rbtNoDemencia_Multiples.Checked Then
                                        bValidoObligatorio = True
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

            Case 4 ''Criterio de ingreso: PARKINSON
                If rbtSiParkinson_Deterioro.Checked Or rbtNoParkinson_Deterioro.Checked Then
                    If rbtSiParkinson_Sintomas.Checked Or rbtNoParkinson_Sintomas.Checked Then
                        If rbtSiParkinson_Problemas.Checked Or rbtNoParkinson_Problemas.Checked Then
                            If rbtSiParkinson_Disfagia.Checked Or rbtNoParkinson_Disfagia.Checked Then
                                If rbtSiParkinson_Neumonia.Checked Or rbtNoParkinson_Neumonia.Checked Then
                                    bValidoObligatorio = True
                                End If
                            End If
                        End If
                    End If
                End If

            Case 5 '''Criterio de ingreso: ELA Y ENFERMEDADES DE MOTONEURONA
                If rbtSiMotoneurona_Deterioro.Checked Or rbtNoMotoneurona_Deterioro.Checked Then
                    If rbtSiMotoneurona_Sintomas.Checked Or rbtNoMotoneurona_Sintomas.Checked Then
                        If rbtSiMotoneurona_Problemas.Checked Or rbtNoMotoneurona_Problemas.Checked Then
                            If rbtSiMotoneurona_Disfagia.Checked Or rbtNoMotoneurona_Disfagia.Checked Then
                                If rbtSiMotoneurona_Neumonia.Checked Or rbtNoMotoneurona_Neumonia.Checked Then
                                    bValidoObligatorio = True
                                End If
                            End If
                        End If
                    End If
                End If
            Case 6 '''Criterio de ingreso: ESCLEROSIS MÚLTIPLE
                If rbtSiEsclerosis_Multiple_Deterioro.Checked Or rbtNoEsclerosis_Multiple_Deterioro.Checked Then
                    If rbtSiEsclerosis_Multiple_Sintomas.Checked Or rbtNoEsclerosis_Multiple_Sintomas.Checked Then
                        If rbtSiEsclerosis_Multiple_Problemas.Checked Or rbtNoEsclerosis_Multiple_Problemas.Checked Then
                            If rbtSiEsclerosis_Multiple_Disfagia.Checked Or rbtNoEsclerosis_Multiple_Disfagia.Checked Then
                                If rbtSiEsclerosis_Multiple_Neumonia.Checked Or rbtNoEsclerosis_Multiple_Neumonia.Checked Then
                                    bValidoObligatorio = True
                                End If
                            End If
                        End If
                    End If
                End If

            Case 7 '''Criterio de ingreso: ENFERMEDAD CARDIACA CRÓNICA
                If rbtSiCardiaca_Cronica_Insuficiencia_Cardiaca.Checked Or rbtNoCardiaca_Cronica_Insuficiencia_Cardiaca.Checked Then
                    If rbtSiCardiaca_Cronica_Disnea.Checked Or rbtNoCardiaca_Cronica_Disnea.Checked Then
                        If rbtSiCardiaca_Cronica_Sintomas.Checked Or rbtNoCardiaca_Cronica_Sintomas.Checked Then
                            If rbtSiCardiaca_Cronica_Ecocardiograma.Checked Or rbtNoCardiaca_Cronica_Ecocardiograma.Checked Then
                                If rbtSiCardiaca_Cronica_Insuficiencia_Renal.Checked Or rbtNoCardiaca_Cronica_Insuficiencia_Renal.Checked Then
                                    If rbtSiCardiaca_Cronica_Ingresos.Checked Or rbtNoCardiaca_Cronica_Ingresos.Checked Then
                                        bValidoObligatorio = True
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

            Case 8 ''Criterio de ingreso: EVENTO CEREBROVASCULAR
                If rbtSiCerebro_Vascular_Cumple_Fragilidad.Checked Or rbtNoCerebro_Vascular_Cumple_Fragilidad.Checked Then
                    If rbtSiCerebro_Vascular_Aprobado.Checked Or rbtNoCerebro_Vascular_Aprobado.Checked Then
                        bValidoObligatorio = True
                    End If
                End If

            Case 9 '''Criterio de ingreso: ENFERMEDAD PULMONAR CRÓNICA
                If rbtSiPulmonar_Cronica_Disnea.Checked Or rbtNoPulmonar_Cronica_Disnea.Checked Then
                    If rbtSiPulmonar_Cronica_Sintomas.Checked Or rbtNoPulmonar_Cronica_Sintomas.Checked Then
                        If rbtSiPulmonar_Cronica_Criterios.Checked Or rbtNoPulmonar_Cronica_Criterios.Checked Then
                            If rbtSiPulmonar_Cronica_En.Checked Or rbtNoPulmonar_Cronica_En.Checked Then
                                If rbtSiPulmonar_Cronica_Insuficiencia.Checked Or rbtNoPulmonar_Cronica_Insuficiencia.Checked Then
                                    If rbtSiPulmonar_Cronica_Ingresos.Checked Or rbtNoPulmonar_Cronica_Ingresos.Checked Then
                                        bValidoObligatorio = True
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Case 10 '''Criterio de ingreso: ENFERMEDAD HEPÁTICA CRÓNICA GRAVE
                If rbtSiHepatica_Cronica_Cirrosis.Checked Or rbtNoHepatica_Cronica_Cirrosis.Checked Then
                    If rbtSiHepatica_Cronica_Puntuacion.Checked Or rbtNoHepatica_Cronica_Puntuacion.Checked Then
                        If rbtSiHepatica_Cronica_Presencia.Checked Or rbtNoHepatica_Cronica_Presencia.Checked Then
                            If rbtSiHepatica_Cronica_Carcinoma.Checked Or rbtNoHepatica_Cronica_Carcinoma.Checked Then
                                bValidoObligatorio = True
                            End If
                        End If
                    End If
                End If

            Case 11 '''Criterio de ingreso: ENFERMEDAD RENAL CRÓNICA GRAVE
                If rbtSiRenal_Cronica_Insuficiencia.Checked Or rbtNoRenal_Cronica_Insuficiencia.Checked Then
                    If rbtSiRenal_Cronica_CriterioFragilidadSevera.Checked Or rbtNoRenal_Cronica_CriterioFragilidadSevera.Checked Then
                        If rbtSiRenal_Cronica_AprobadoJuntaPaliativa.Checked Or rbtNoRenal_Cronica_AprobadoJuntaPaliativa.Checked Then
                            bValidoObligatorio = True
                            ''Si, Si, Si
                            If rbtSiRenal_Cronica_Insuficiencia.Checked And rbtSiRenal_Cronica_CriterioFragilidadSevera.Checked And rbtSiRenal_Cronica_AprobadoJuntaPaliativa.Checked Then
                                rbtSiRenal_Cronica_Cumple.Checked = True
                            End If
                            ''Si, Si, No
                            If rbtSiRenal_Cronica_Insuficiencia.Checked And rbtSiRenal_Cronica_CriterioFragilidadSevera.Checked And rbtNoRenal_Cronica_AprobadoJuntaPaliativa.Checked Then
                                rbtSiRenal_Cronica_Cumple.Checked = True
                            End If
                            ''No, Si, sI
                            If rbtNoRenal_Cronica_Insuficiencia.Checked And rbtSiRenal_Cronica_CriterioFragilidadSevera.Checked And rbtSiRenal_Cronica_AprobadoJuntaPaliativa.Checked Then
                                rbtSiRenal_Cronica_Cumple.Checked = True
                            End If
                            ''Si,No,Si
                            If rbtSiRenal_Cronica_Insuficiencia.Checked And rbtNoRenal_Cronica_CriterioFragilidadSevera.Checked And rbtSiRenal_Cronica_AprobadoJuntaPaliativa.Checked Then
                                rbtSiRenal_Cronica_Cumple.Checked = True
                            End If
                            ''No,No,No
                            If rbtNoRenal_Cronica_Insuficiencia.Checked And rbtNoRenal_Cronica_CriterioFragilidadSevera.Checked And rbtNoRenal_Cronica_AprobadoJuntaPaliativa.Checked Then
                                rbtNoRenal_Cronica_Cumple.Checked = True
                            End If
                            ''No,No,Si
                            If rbtNoRenal_Cronica_Insuficiencia.Checked And rbtNoRenal_Cronica_CriterioFragilidadSevera.Checked And rbtSiRenal_Cronica_AprobadoJuntaPaliativa.Checked Then
                                rbtNoRenal_Cronica_Cumple.Checked = True
                            End If
                            ''Si,No,No
                            If rbtSiRenal_Cronica_Insuficiencia.Checked And rbtNoRenal_Cronica_CriterioFragilidadSevera.Checked And rbtNoRenal_Cronica_AprobadoJuntaPaliativa.Checked Then
                                rbtNoRenal_Cronica_Cumple.Checked = True
                            End If
                            ''No,Si,No
                            If rbtNoRenal_Cronica_Insuficiencia.Checked And rbtSiRenal_Cronica_CriterioFragilidadSevera.Checked And rbtNoRenal_Cronica_AprobadoJuntaPaliativa.Checked Then
                                rbtNoRenal_Cronica_Cumple.Checked = True
                            End If
                        End If
                    End If
                End If

            Case 12 '''Criterio de ingreso: FRAGILIDAD SEVERA
                If rbtSiFragilidad_Severa_Deterioro.Checked Or rbtNoFragilidad_Severa_Deterioro.Checked Then
                    If rbtSiFragilidad_Severa_Perdida_Peso.Checked Or rbtNoFragilidad_Severa_Perdida_Peso.Checked Then
                        If rbtSiFragilidad_Severa_Albumina.Checked Or rbtNoFragilidad_Severa_Albumina.Checked Or rbtSDFragilidad_Severa_Albumina.Checked Then
                            If rbtSiFragilidad_Severa_Impresion.Checked Or rbtNoFragilidad_Severa_Impresion.Checked Then
                                If rbtSiFragilidad_Severa_Barthel.Checked Or rbtNoFragilidad_Severa_Barthel.Checked Then
                                    If rbtSiFragilidad_Severa_Pps.Checked Or rbtNoFragilidad_Severa_Pps.Checked Then
                                        If rbtSiFragilidad_Severa_Perdida_Actividades.Checked Or rbtNoFragilidad_Severa_Perdida_Actividades.Checked Then
                                            If rbtSiFragilidad_Severa_Ulceras.Checked Or rbtNoFragilidad_Severa_Ulceras.Checked Then
                                                If rbtSiFragilidad_Severa_Infecciones.Checked Or rbtNoFragilidad_Severa_Infecciones.Checked Then
                                                    If rbtSiFragilidad_Severa_Delirium.Checked Or rbtNoFragilidad_Severa_Delirium.Checked Then
                                                        If rbtSiFragilidad_Severa_Disfagia.Checked Or rbtNoFragilidad_Severa_Disfagia.Checked Then
                                                            If rbtSiFragilidad_Severa_Caidas.Checked Or rbtNoFragilidad_Severa_Caidas.Checked Then
                                                                If rbtSiFragilidad_Severa_Sintomas.Checked Or rbtNoFragilidad_Severa_Sintomas.Checked Then
                                                                    If rbtSiFragilidad_Severa_Mas_Ingresos.Checked Or rbtNoFragilidad_Severa_Mas_Ingresos.Checked Then
                                                                        If rbtSiFragilidad_Severa_Necesidad.Checked Or rbtNoFragilidad_Severa_Necesidad.Checked Then
                                                                            If rbtSiFragilidad_Severa_Mas_Patologias.Checked Or rbtNoFragilidad_Severa_Mas_Patologias.Checked Then
                                                                                bValidoObligatorio = True
                                                                            End If
                                                                        End If
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

        End Select

        bfncObligatoriedad = bValidoObligatorio
    End Function

    ''' <summary>
    '''Marca el cumplimiento del criterio según corresponda
    ''' </summary>
    ''' <param name="oRadioButton">Recibe el radioButton seleccionado</param>
    ''' <remarks></remarks>
    Private Sub MarcaCumplimiento(ByVal oRadioButton As RadioButton)
        Try
            Dim aNombreControl() As String
            Dim sNombreGrupo As String
            Dim sVarlorRespuesta As String

            aNombreControl = Split(oRadioButton.Name, "_")

            sNombreGrupo = aNombreControl(0).Substring(5)
            sVarlorRespuesta = aNombreControl(0).Substring(3, 2)

            ''WACHV, INICIO, 18Sept2017,Validar que sean obligatorias
            If Not bfncObligatoriedad(iCriterio) Then
                ''MessageBox.Show("Debe seleccionar todas los Respuestas")
                Exit Sub
            End If  ''WACHV, FIN, 18Sept2017,Validar que sean obligatorias


            ''WACHV, INICIO, 18Sept2017,Comentado
            '''If sNombreGrupo = "Oncologica" And sVarlorRespuesta = "No" And oRadioButton.Checked Then
            '''    rbtNoOncologica_Cumple.Checked = True
            '''End If


            '''If sNombreGrupo = "VIHSIDA" And sVarlorRespuesta = "No" And oRadioButton.Checked Then
            '''    rbtNoVIHSIDA_Cumple.Checked = True
            '''End If

            ''WACHV, FIN, 18Sept2017,Comentado

            If sNombreGrupo = "Demencia" And sVarlorRespuesta = "No" And oRadioButton.Checked Then
                If (oRadioButton.Name = rbtNoDemencia_Incapacidad_Vestirse.Name _
                    Or oRadioButton.Name = rbtNoDemencia_Aparicion_Incontinencia.Name _
                    Or oRadioButton.Name = rbtNoDemencia_Incapacidad_Hablar.Name) Then
                    If iDemenciaSeveridad > 0 Then
                        iDemenciaSeveridad = 0
                    End If
                End If

                If oRadioButton.Name = rbtNoDemencia_Perdida.Name _
                    Or oRadioButton.Name = rbtNoDemencia_Aparicion_Dificultad.Name _
                Then
                    If iDemenciaProgresion > 0 Then
                        iDemenciaProgresion = 0
                    End If

                End If

                If oRadioButton.Name = rbtNoDemencia_Multiples.Name _
                Then
                    If iDemenciaUsoRecursos > 0 Then
                        iDemenciaUsoRecursos = 0
                    End If

                End If
                rbtNoCumple_Demencia.Checked = True
            End If
            If sNombreGrupo = "Parkinson" And sVarlorRespuesta = "No" And oRadioButton.Checked Then
                rbtNoParkinson_Cumple.Checked = True
            End If
            If sNombreGrupo = "Motoneurona" And sVarlorRespuesta = "No" And oRadioButton.Checked Then
                rbtNoMotoneurona_Cumple.Checked = True
            End If
            If sNombreGrupo = "Esclerosis" And sVarlorRespuesta = "No" And oRadioButton.Checked Then
                rbtNoEsclerosis_Multiple_Cumple.Checked = True
            End If
            If sNombreGrupo = "Cardiaca" And sVarlorRespuesta = "No" And oRadioButton.Checked Then
                rbtNoCardiaca_Cronica_Cumple.Checked = True
            End If
            If sNombreGrupo = "Cerebro" And sVarlorRespuesta = "No" And oRadioButton.Checked Then
                rbtNoCerebro_Vascular_Cumple.Checked = True
            End If
            If sNombreGrupo = "Pulmonar" And sVarlorRespuesta = "No" And oRadioButton.Checked Then
                rbtNoPulmonar_Cronica_Cumple.Checked = True
            End If
            If sNombreGrupo = "Hepatica" And sVarlorRespuesta = "No" And oRadioButton.Checked Then
                rbtNoHepatica_Cronica_Cumple.Checked = True
            End If

            ''WACHV, INICIO, 19Sept2017,Comentado
            'If sNombreGrupo = "Renal" And sVarlorRespuesta = "No" And oRadioButton.Checked Then
            '    rbtNoRenal_Cronica_Cumple.Checked = True
            'End If
            ''WACHV, FIN, 19Sept2017,Comentado

            If sNombreGrupo = "Fragilidad" And sVarlorRespuesta = "No" And oRadioButton.Checked Then

                If (oRadioButton.Name = rbtNoFragilidad_Severa_Deterioro.Name _
                    Or oRadioButton.Name = rbtNoFragilidad_Severa_Perdida_Peso.Name _
                    Or oRadioButton.Name = rbtNoFragilidad_Severa_Albumina.Name) Then
                    If iFragilidadNutricional > 0 Then
                        iFragilidadNutricional = 0
                    End If
                End If

                If oRadioButton.Name = rbtNoFragilidad_Severa_Impresion.Name _
                    Or oRadioButton.Name = rbtNoFragilidad_Severa_Barthel.Name _
                    Or oRadioButton.Name = rbtNoFragilidad_Severa_Pps.Name _
                    Or oRadioButton.Name = rbtNoFragilidad_Severa_Perdida_Actividades.Name _
                Then
                    If iFragilidadFuncional > 0 Then
                        iFragilidadFuncional = 0
                    End If

                End If

                If oRadioButton.Name = rbtNoFragilidad_Severa_Ulceras.Name _
                    Or oRadioButton.Name = rbtNoFragilidad_Severa_Infecciones.Name _
                    Or oRadioButton.Name = rbtNoFragilidad_Severa_Delirium.Name _
                    Or oRadioButton.Name = rbtNoFragilidad_Severa_Disfagia.Name _
                    Or oRadioButton.Name = rbtNoFragilidad_Severa_Caidas.Name _
                    Or oRadioButton.Name = rbtNoFragilidad_Severa_Sintomas.Name _
                    Or oRadioButton.Name = rbtNoFragilidad_Severa_Mas_Ingresos.Name _
                    Or oRadioButton.Name = rbtNoFragilidad_Severa_Necesidad.Name _
                    Or oRadioButton.Name = rbtNoFragilidad_Severa_Mas_Patologias.Name _
                Then
                    If iFragilidadGlobal > 0 Then
                        iFragilidadGlobal = 0
                    End If

                End If
                rbtNoFragilidad_Severa_Cumple.Checked = True
            End If

            ''WACHV, INICIO, 18Sept2017,Comentado
            '''If sNombreGrupo = "Oncologica" And sVarlorRespuesta = "Si" And oRadioButton.Checked Then
            '''    rbtSiOncologica_Cumple.Checked = True
            '''End If
            '''If sNombreGrupo = "VIHSIDA" And sVarlorRespuesta = "Si" And oRadioButton.Checked Then
            '''    rbtSiVIHSIDA_Cumple.Checked = True
            '''End If

            ''WACHV, FIN, 18Sept2017,Comentado

            If sNombreGrupo = "Demencia" And sVarlorRespuesta = "Si" And oRadioButton.Checked Then

                If oRadioButton.Name = rbtSiDemencia_Incapacidad_Vestirse.Name _
                    Or oRadioButton.Name = rbtSiDemencia_Aparicion_Incontinencia.Name _
                    Or oRadioButton.Name = rbtSiDemencia_Incapacidad_Hablar.Name _
                Then
                    iDemenciaSeveridad = 1
                End If

                If oRadioButton.Name = rbtSiDemencia_Perdida.Name _
                    Or oRadioButton.Name = rbtSiDemencia_Aparicion_Dificultad.Name _
                Then
                    iDemenciaProgresion = 1
                End If

                If oRadioButton.Name = rbtSiDemencia_Multiples.Name _
                Then
                    iDemenciaUsoRecursos = 1
                End If

                If iDemenciaSeveridad > 0 And (iDemenciaProgresion + iDemenciaUsoRecursos) > 0 Then
                    rbtSiCumple_Demencia.Checked = True
                Else
                    rbtNoCumple_Demencia.Checked = True
                End If
            End If
            If sNombreGrupo = "Parkinson" And sVarlorRespuesta = "Si" And oRadioButton.Checked Then
                iParkinson += 1
                If iParkinson > 1 Then
                    rbtSiParkinson_Cumple.Checked = True
                Else
                    rbtNoParkinson_Cumple.Checked = True
                End If
            End If
            If sNombreGrupo = "Motoneurona" And sVarlorRespuesta = "Si" And oRadioButton.Checked Then
                iMotoNeurona += 1
                If iMotoNeurona > 1 Then
                    rbtSiMotoneurona_Cumple.Checked = True
                Else
                    rbtNoMotoneurona_Cumple.Checked = True
                End If
            End If
            If sNombreGrupo = "Esclerosis" And sVarlorRespuesta = "Si" And oRadioButton.Checked Then
                iEsclerosis += 1
                If iEsclerosis > 1 Then
                    rbtSiEsclerosis_Multiple_Cumple.Checked = True
                Else
                    rbtNoEsclerosis_Multiple_Cumple.Checked = True
                End If
            End If
            If sNombreGrupo = "Cardiaca" And sVarlorRespuesta = "Si" And oRadioButton.Checked Then
                iCardiaca += 1
                If iCardiaca > 1 Then
                    rbtSiCardiaca_Cronica_Cumple.Checked = True
                Else
                    rbtNoCardiaca_Cronica_Cumple.Checked = True
                End If
            End If
            If sNombreGrupo = "Cerebro" And sVarlorRespuesta = "Si" And oRadioButton.Checked Then
                iCerebroVascular += 1
                If iCerebroVascular > 1 Then
                    rbtSiCerebro_Vascular_Cumple.Checked = True
                Else
                    rbtNoCerebro_Vascular_Cumple.Checked = True
                End If
            End If
            If sNombreGrupo = "Pulmonar" And sVarlorRespuesta = "Si" And oRadioButton.Checked Then
                iPulmonar += 1
                If iPulmonar > 1 Then
                    rbtSiPulmonar_Cronica_Cumple.Checked = True
                Else
                    rbtNoPulmonar_Cronica_Cumple.Checked = True
                End If
            End If
            If sNombreGrupo = "Hepatica" And sVarlorRespuesta = "Si" And oRadioButton.Checked Then
                rbtSiHepatica_Cronica_Cumple.Checked = True
            End If

            ''WACHV, INICIO, 18Sept2017,Comentado
            'If sNombreGrupo = "Renal" And sVarlorRespuesta = "Si" And oRadioButton.Checked Then
            '    rbtSiRenal_Cronica_Cumple.Checked = True
            'End If
            ''WACHV, FIN, 18Sept2017,Comentado

            If sNombreGrupo = "Fragilidad" And sVarlorRespuesta = "Si" And oRadioButton.Checked Then
                If oRadioButton.Name = rbtSiFragilidad_Severa_Deterioro.Name _
                                    Or oRadioButton.Name = rbtSiFragilidad_Severa_Perdida_Peso.Name _
                                    Or oRadioButton.Name = rbtSiFragilidad_Severa_Albumina.Name _
                                Then
                    iFragilidadNutricional = 1
                End If

                If oRadioButton.Name = rbtSiFragilidad_Severa_Impresion.Name _
                    Or oRadioButton.Name = rbtSiFragilidad_Severa_Barthel.Name _
                    Or oRadioButton.Name = rbtSiFragilidad_Severa_Pps.Name _
                    Or oRadioButton.Name = rbtSiFragilidad_Severa_Perdida_Actividades.Name _
                Then
                    iFragilidadFuncional = 1
                End If

                If oRadioButton.Name = rbtSiFragilidad_Severa_Ulceras.Name _
                    Or oRadioButton.Name = rbtSiFragilidad_Severa_Infecciones.Name _
                    Or oRadioButton.Name = rbtSiFragilidad_Severa_Delirium.Name _
                    Or oRadioButton.Name = rbtSiFragilidad_Severa_Disfagia.Name _
                    Or oRadioButton.Name = rbtSiFragilidad_Severa_Caidas.Name _
                    Or oRadioButton.Name = rbtSiFragilidad_Severa_Sintomas.Name _
                    Or oRadioButton.Name = rbtSiFragilidad_Severa_Mas_Ingresos.Name _
                    Or oRadioButton.Name = rbtSiFragilidad_Severa_Necesidad.Name _
                    Or oRadioButton.Name = rbtSiFragilidad_Severa_Mas_Patologias.Name _
                Then
                    iFragilidadGlobal += 1
                End If

                If iFragilidadNutricional > 0 And iFragilidadFuncional > 0 And iFragilidadGlobal > 1 Then
                    rbtSiFragilidad_Severa_Cumple.Checked = True
                Else
                    rbtNoFragilidad_Severa_Cumple.Checked = True
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' Marca el cumplimiento del criterio Enfermedad Oncológica
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MarcaCumplimientoGrupoOncologica()

        MarcaCumplimiento(rbtNoOncologica_Diagnostico)
        MarcaCumplimiento(rbtNoOncologica_Deterioro)
        MarcaCumplimiento(rbtNoOncologica_Sintomas)

        MarcaCumplimiento(rbtSiOncologica_Sintomas)
        MarcaCumplimiento(rbtSiOncologica_Deterioro)
        MarcaCumplimiento(rbtSiOncologica_Diagnostico)

    End Sub

    ''' <summary>
    ''' Marca el cumplimiento del criterio VIH/SIDA
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MarcaCumplimientoGrupoVIHSIDA()
        MarcaCumplimiento(rbtNoVIHSIDA_Criterio)
        MarcaCumplimiento(rbtNoVIHSIDA_Aprobado)

        MarcaCumplimiento(rbtSiVIHSIDA_Criterio)
        MarcaCumplimiento(rbtSiVIHSIDA_Aprobado)
    End Sub

    ''' <summary>
    ''' Marca el cumplimiento del criterio Demencia
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MarcaCumplimientoGrupoDemencia()

        MarcaCumplimiento(rbtNoDemencia_Incapacidad_Vestirse)
        MarcaCumplimiento(rbtNoDemencia_Aparicion_Incontinencia)
        MarcaCumplimiento(rbtNoDemencia_Incapacidad_Hablar)
        MarcaCumplimiento(rbtNoDemencia_Perdida)
        MarcaCumplimiento(rbtNoDemencia_Aparicion_Dificultad)
        MarcaCumplimiento(rbtNoDemencia_Multiples)

        MarcaCumplimiento(rbtSiDemencia_Incapacidad_Vestirse)
        MarcaCumplimiento(rbtSiDemencia_Aparicion_Incontinencia)
        MarcaCumplimiento(rbtSiDemencia_Incapacidad_Hablar)
        MarcaCumplimiento(rbtSiDemencia_Perdida)
        MarcaCumplimiento(rbtSiDemencia_Aparicion_Dificultad)
        MarcaCumplimiento(rbtSiDemencia_Multiples)

    End Sub

    ''' <summary>
    ''' Marca el cumplimiento del criterio Parkinson
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MarcaCumplimientoGrupoParkinson()

        MarcaCumplimiento(rbtNoParkinson_Deterioro)
        MarcaCumplimiento(rbtNoParkinson_Sintomas)
        MarcaCumplimiento(rbtNoParkinson_Problemas)
        MarcaCumplimiento(rbtNoParkinson_Disfagia)
        MarcaCumplimiento(rbtNoParkinson_Neumonia)

        MarcaCumplimiento(rbtSiParkinson_Deterioro)
        MarcaCumplimiento(rbtSiParkinson_Sintomas)
        MarcaCumplimiento(rbtSiParkinson_Problemas)
        MarcaCumplimiento(rbtSiParkinson_Disfagia)
        MarcaCumplimiento(rbtSiParkinson_Neumonia)

    End Sub

    ''' <summary>
    ''' Marca el cumplimiento del criterio ELA Y ENFERMEDADES DE MOTONEURONA
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MarcaCumplimientoGrupoMotoneurona()

        MarcaCumplimiento(rbtNoMotoneurona_Deterioro)
        MarcaCumplimiento(rbtNoMotoneurona_Sintomas)
        MarcaCumplimiento(rbtNoMotoneurona_Problemas)
        MarcaCumplimiento(rbtNoMotoneurona_Disfagia)
        MarcaCumplimiento(rbtNoMotoneurona_Neumonia)

        MarcaCumplimiento(rbtSiMotoneurona_Deterioro)
        MarcaCumplimiento(rbtSiMotoneurona_Sintomas)
        MarcaCumplimiento(rbtSiMotoneurona_Problemas)
        MarcaCumplimiento(rbtSiMotoneurona_Disfagia)
        MarcaCumplimiento(rbtSiMotoneurona_Neumonia)

    End Sub

    ''' <summary>
    ''' Marca el cumplimiento del criterio ESCLEROSIS MÚLTIPLE
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MarcaCumplimientoGrupoEsclerosis()

        MarcaCumplimiento(rbtNoEsclerosis_Multiple_Deterioro)
        MarcaCumplimiento(rbtNoEsclerosis_Multiple_Sintomas)
        MarcaCumplimiento(rbtNoEsclerosis_Multiple_Problemas)
        MarcaCumplimiento(rbtNoEsclerosis_Multiple_Disfagia)
        MarcaCumplimiento(rbtNoEsclerosis_Multiple_Neumonia)

        MarcaCumplimiento(rbtSiEsclerosis_Multiple_Deterioro)
        MarcaCumplimiento(rbtSiEsclerosis_Multiple_Sintomas)
        MarcaCumplimiento(rbtSiEsclerosis_Multiple_Problemas)
        MarcaCumplimiento(rbtSiEsclerosis_Multiple_Disfagia)
        MarcaCumplimiento(rbtSiEsclerosis_Multiple_Neumonia)

    End Sub

    ''' <summary>
    ''' Marca el cumplimiento del criterio ENFERMEDAD CARDIACA CRÓNICA
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MarcaCumplimientoGrupoCardiaca()

        MarcaCumplimiento(rbtNoCardiaca_Cronica_Insuficiencia_Cardiaca)
        MarcaCumplimiento(rbtNoCardiaca_Cronica_Disnea)
        MarcaCumplimiento(rbtNoCardiaca_Cronica_Sintomas)
        MarcaCumplimiento(rbtNoCardiaca_Cronica_Ecocardiograma)
        MarcaCumplimiento(rbtNoCardiaca_Cronica_Insuficiencia_Renal)
        MarcaCumplimiento(rbtNoCardiaca_Cronica_Ingresos)

        MarcaCumplimiento(rbtSiCardiaca_Cronica_Insuficiencia_Cardiaca)
        MarcaCumplimiento(rbtSiCardiaca_Cronica_Disnea)
        MarcaCumplimiento(rbtSiCardiaca_Cronica_Sintomas)
        MarcaCumplimiento(rbtSiCardiaca_Cronica_Ecocardiograma)
        MarcaCumplimiento(rbtSiCardiaca_Cronica_Insuficiencia_Renal)
        MarcaCumplimiento(rbtSiCardiaca_Cronica_Ingresos)

    End Sub

    ''' <summary>
    ''' Marca el cumplimiento del criterio EVENTO CEREBROVASCULAR
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MarcaCumplimientoGrupoCerebro()
        MarcaCumplimiento(rbtNoCerebro_Vascular_Cumple_Fragilidad)
        MarcaCumplimiento(rbtNoCerebro_Vascular_Aprobado)

        MarcaCumplimiento(rbtSiCerebro_Vascular_Cumple_Fragilidad)
        MarcaCumplimiento(rbtSiCerebro_Vascular_Aprobado)

    End Sub

    ''' <summary>
    ''' Marca el cumplimiento del criterio ENFERMEDAD PULMONAR CRÓNICA
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MarcaCumplimientoGrupoPulmonar()

        MarcaCumplimiento(rbtNoPulmonar_Cronica_Disnea)
        MarcaCumplimiento(rbtNoPulmonar_Cronica_Sintomas)
        MarcaCumplimiento(rbtNoPulmonar_Cronica_Criterios)
        MarcaCumplimiento(rbtNoPulmonar_Cronica_En)
        MarcaCumplimiento(rbtNoPulmonar_Cronica_Insuficiencia)
        MarcaCumplimiento(rbtNoPulmonar_Cronica_Ingresos)

        MarcaCumplimiento(rbtSiPulmonar_Cronica_Disnea)
        MarcaCumplimiento(rbtSiPulmonar_Cronica_Sintomas)
        MarcaCumplimiento(rbtSiPulmonar_Cronica_Criterios)
        MarcaCumplimiento(rbtSiPulmonar_Cronica_En)
        MarcaCumplimiento(rbtSiPulmonar_Cronica_Insuficiencia)
        MarcaCumplimiento(rbtSiPulmonar_Cronica_Ingresos)

    End Sub

    ''' <summary>
    ''' Marca el cumplimiento del criterio ENFERMEDAD HEPÁTICA CRÓNICA GRAVE
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MarcaCumplimientoGrupoHepatica()

        MarcaCumplimiento(rbtNoHepatica_Cronica_Cirrosis)
        MarcaCumplimiento(rbtNoHepatica_Cronica_Puntuacion)
        MarcaCumplimiento(rbtNoHepatica_Cronica_Presencia)
        MarcaCumplimiento(rbtNoHepatica_Cronica_Carcinoma)

        MarcaCumplimiento(rbtSiHepatica_Cronica_Cirrosis)
        MarcaCumplimiento(rbtSiHepatica_Cronica_Puntuacion)
        MarcaCumplimiento(rbtSiHepatica_Cronica_Presencia)
        MarcaCumplimiento(rbtSiHepatica_Cronica_Carcinoma)

    End Sub

    ''' <summary>
    ''' Marca el cumplimiento del criterio ENFERMEDAD RENAL CRÓNICA GRAVE
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MarcaCumplimientoGrupoRenal()

        MarcaCumplimiento(rbtNoRenal_Cronica_Insuficiencia)
        MarcaCumplimiento(rbtSiRenal_Cronica_Insuficiencia)
        MarcaCumplimiento(rbtSiRenal_Cronica_CriterioFragilidadSevera)
        MarcaCumplimiento(rbtNoRenal_Cronica_CriterioFragilidadSevera)
        MarcaCumplimiento(rbtSiRenal_Cronica_AprobadoJuntaPaliativa)
        MarcaCumplimiento(rbtNoRenal_Cronica_AprobadoJuntaPaliativa)

    End Sub

    ''' <summary>
    ''' Marca el cumplimiento del criterio FRAGILIDAD SEVERA
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MarcaCumplimientoGrupoFragilidad()

        MarcaCumplimiento(rbtNoFragilidad_Severa_Perdida_Peso)
        MarcaCumplimiento(rbtNoFragilidad_Severa_Deterioro)
        MarcaCumplimiento(rbtNoFragilidad_Severa_Albumina)
        MarcaCumplimiento(rbtNoFragilidad_Severa_Impresion)
        MarcaCumplimiento(rbtNoFragilidad_Severa_Barthel)
        MarcaCumplimiento(rbtNoFragilidad_Severa_Pps)
        MarcaCumplimiento(rbtNoFragilidad_Severa_Perdida_Actividades)
        MarcaCumplimiento(rbtNoFragilidad_Severa_Ulceras)
        MarcaCumplimiento(rbtNoFragilidad_Severa_Infecciones)
        MarcaCumplimiento(rbtNoFragilidad_Severa_Delirium)
        MarcaCumplimiento(rbtNoFragilidad_Severa_Disfagia)
        MarcaCumplimiento(rbtNoFragilidad_Severa_Caidas)
        MarcaCumplimiento(rbtNoFragilidad_Severa_Sintomas)
        MarcaCumplimiento(rbtNoFragilidad_Severa_Mas_Ingresos)
        MarcaCumplimiento(rbtNoFragilidad_Severa_Necesidad)
        MarcaCumplimiento(rbtNoFragilidad_Severa_Mas_Patologias)

        MarcaCumplimiento(rbtSiFragilidad_Severa_Perdida_Peso)
        MarcaCumplimiento(rbtSiFragilidad_Severa_Deterioro)
        MarcaCumplimiento(rbtSiFragilidad_Severa_Albumina)
        MarcaCumplimiento(rbtSiFragilidad_Severa_Impresion)
        MarcaCumplimiento(rbtSiFragilidad_Severa_Barthel)
        MarcaCumplimiento(rbtSiFragilidad_Severa_Pps)
        MarcaCumplimiento(rbtSiFragilidad_Severa_Perdida_Actividades)
        MarcaCumplimiento(rbtSiFragilidad_Severa_Ulceras)
        MarcaCumplimiento(rbtSiFragilidad_Severa_Infecciones)
        MarcaCumplimiento(rbtSiFragilidad_Severa_Delirium)
        MarcaCumplimiento(rbtSiFragilidad_Severa_Disfagia)
        MarcaCumplimiento(rbtSiFragilidad_Severa_Caidas)
        MarcaCumplimiento(rbtSiFragilidad_Severa_Sintomas)
        MarcaCumplimiento(rbtSiFragilidad_Severa_Mas_Ingresos)
        MarcaCumplimiento(rbtSiFragilidad_Severa_Necesidad)
        MarcaCumplimiento(rbtSiFragilidad_Severa_Mas_Patologias)

    End Sub


#End Region

End Class

