Imports System.Collections.Generic
Imports HistoriaClinica.wsCuidadoPaliativo
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Public Class CriterioIngreso

#Region "Properties"

    Private _cod_pre_sgs As String
    Private _cod_sucur As String
    Private _tip_admision As String
    Private _ano_adm As Integer
    Private _num_adm As Decimal
    Private _tip_doc As String
    Private _Num_doc As String
    Private _Oncologica_Diagnostico As Integer
    Private _Oncologica_Deterioro As Integer
    Private _Oncologica_Sintomas As Integer
    Private _Oncologica_Cumple As Integer
    Private _VIHSIDA_Criterio As Integer
    Private _VIHSIDA_Aprobado As Integer
    Private _VIHSIDA_Cumple As Integer
    Private _Demencia_Incapacidad_Vestirse As Integer
    Private _Demencia_Aparicion_Incontinencia As Integer
    Private _Demencia_Incapacidad_Hablar As Integer
    Private _Demencia_Perdida As Integer
    Private _Demencia_Aparicion_Dificultad As Integer
    Private _Demencia_Multiples As Integer
    Private _Cumple_Demencia As Integer
    Private _Parkinson_Deterioro As Integer
    Private _Parkinson_Sintomas As Integer
    Private _Parkinson_Problemas As Integer
    Private _Parkinson_Disfagia As Integer
    Private _Parkinson_Neumonia As Integer
    Private _Parkinson_Cumple As Integer
    Private _Motoneurona_Deterioro As Integer
    Private _Motoneurona_Sintomas As Integer
    Private _Motoneurona_Problemas As Integer
    Private _Motoneurona_Disfagia As Integer
    Private _Motoneurona_Neumonia As Integer
    Private _Motoneurona_Cumple As Integer
    Private _Esclerosis_Multiple_Deterioro As Integer
    Private _Esclerosis_Multiple_Sintomas As Integer
    Private _Esclerosis_Multiple_Problemas As Integer
    Private _Esclerosis_Multiple_Disfagia As Integer
    Private _Esclerosis_Multiple_Neumonia As Integer
    Private _Esclerosis_Multiple_Cumple As Integer
    Private _Cardiaca_Cronica_Insuficiencia_Cardiaca As Integer
    Private _Cardiaca_Cronica_Disnea As Integer
    Private _Cardiaca_Cronica_Sintomas As Integer
    Private _Cardiaca_Cronica_Ecocardiograma As Integer
    Private _Cardiaca_Cronica_Insuficiencia_Renal As Integer
    Private _Cardiaca_Cronica_Ingresos As Integer
    Private _Cardiaca_Cronica_Cumple As Integer
    Private _Cerebro_Vascular_Cumple_Fragilidad As Integer
    Private _Cerebro_Vascular_Aprobado As Integer
    Private _Cerebro_Vascular_Cumple As Integer
    Private _Pulmonar_Cronica_Disnea As Integer
    Private _Pulmonar_Cronica_Sintomas As Integer
    Private _Pulmonar_Cronica_Criterios As Integer
    Private _Pulmonar_Cronica_En As Integer
    Private _Pulmonar_Cronica_Insuficiencia As Integer
    Private _Pulmonar_Cronica_Ingresos As Integer
    Private _Pulmonar_Cronica_Cumple As Integer
    Private _Hepatica_Cronica_Cirrosis As Integer
    Private _Hepatica_Cronica_Puntuacion As Integer
    Private _Hepatica_Cronica_Presencia As Integer
    Private _Hepatica_Cronica_Carcinoma As Integer
    Private _Hepatica_Cronica_Cumple As Integer
    Private _Renal_Cronica_Insuficiencia As Integer
    'WACHV, INICIO,NUEVAS PREGUNTAS
    Private _Renal_Cronica_CriterioFragilidadSevera As Integer
    Private _Renal_Cronica_AprobadoJuntaPaliativa As Integer
    'WACHV, FIN,NUEVAS PREGUNTAS
    Private _Renal_Cronica_Cumple As Integer
    Private _Fragilidad_Severa_Deterioro As Integer
    Private _Fragilidad_Severa_Perdida_Peso As Integer
    Private _Fragilidad_Severa_Albumina As Integer
    Private _Fragilidad_Severa_Impresion As Integer
    Private _Fragilidad_Severa_Barthel As Integer
    Private _Fragilidad_Severa_Pps As Integer
    Private _Fragilidad_Severa_Perdida_Actividades As Integer
    Private _Fragilidad_Severa_Ulceras As Integer
    Private _Fragilidad_Severa_Infecciones As Integer
    Private _Fragilidad_Severa_Delirium As Integer
    Private _Fragilidad_Severa_Disfagia As Integer
    Private _Fragilidad_Severa_Caidas As Integer
    Private _Fragilidad_Severa_Sintomas As Integer
    Private _Fragilidad_Severa_Mas_Ingresos As Integer
    Private _Fragilidad_Severa_Necesidad As Integer
    Private _Fragilidad_Severa_Mas_Patologias As Integer
    Private _Fragilidad_Severa_Cumple As Integer
    Private _fec_con As DateTime
    Private _obs As String
    Private _login As String
    Public ReadOnly SeccionCriterioIngreso As Integer = 8


    Public Property cod_pre_sgs() As String
        Get
            Return _cod_pre_sgs
        End Get
        Set(ByVal Value As String)
            _cod_pre_sgs = Value
        End Set
    End Property

    Public Property cod_sucur() As String
        Get
            Return _cod_sucur
        End Get
        Set(ByVal Value As String)
            _cod_sucur = Value
        End Set
    End Property

    Public Property tip_admision() As String
        Get
            Return _tip_admision
        End Get
        Set(ByVal Value As String)
            _tip_admision = Value
        End Set
    End Property

    Public Property ano_adm() As Integer
        Get
            Return _ano_adm
        End Get
        Set(ByVal Value As Integer)
            _ano_adm = Value
        End Set
    End Property

    Public Property num_adm() As Decimal
        Get
            Return _num_adm
        End Get
        Set(ByVal Value As Decimal)
            _num_adm = Value
        End Set
    End Property

    Public Property tip_doc() As String
        Get
            Return _tip_doc
        End Get
        Set(ByVal Value As String)
            _tip_doc = Value
        End Set
    End Property

    Public Property Num_doc() As String
        Get
            Return _Num_doc
        End Get
        Set(ByVal Value As String)
            _Num_doc = Value
        End Set
    End Property

    Public Property Oncologica_Diagnostico() As Integer
        Get
            Return _Oncologica_Diagnostico
        End Get
        Set(ByVal Value As Integer)
            _Oncologica_Diagnostico = Value
        End Set
    End Property

    Public Property Oncologica_Deterioro() As Integer
        Get
            Return _Oncologica_Deterioro
        End Get
        Set(ByVal Value As Integer)
            _Oncologica_Deterioro = Value
        End Set
    End Property

    Public Property Oncologica_Sintomas() As Integer
        Get
            Return _Oncologica_Sintomas
        End Get
        Set(ByVal Value As Integer)
            _Oncologica_Sintomas = Value
        End Set
    End Property

    Public Property Oncologica_Cumple() As Integer
        Get
            Return _Oncologica_Cumple
        End Get
        Set(ByVal Value As Integer)
            _Oncologica_Cumple = Value
        End Set
    End Property

    Public Property VIHSIDA_Criterio() As Integer
        Get
            Return _VIHSIDA_Criterio
        End Get
        Set(ByVal Value As Integer)
            _VIHSIDA_Criterio = Value
        End Set
    End Property

    Public Property VIHSIDA_Aprobado() As Integer
        Get
            Return _VIHSIDA_Aprobado
        End Get
        Set(ByVal Value As Integer)
            _VIHSIDA_Aprobado = Value
        End Set
    End Property

    Public Property VIHSIDA_Cumple() As Integer
        Get
            Return _VIHSIDA_Cumple
        End Get
        Set(ByVal Value As Integer)
            _VIHSIDA_Cumple = Value
        End Set
    End Property

    Public Property Demencia_Incapacidad_Vestirse() As Integer
        Get
            Return _Demencia_Incapacidad_Vestirse
        End Get
        Set(ByVal Value As Integer)
            _Demencia_Incapacidad_Vestirse = Value
        End Set
    End Property

    Public Property Demencia_Aparicion_Incontinencia() As Integer
        Get
            Return _Demencia_Aparicion_Incontinencia
        End Get
        Set(ByVal Value As Integer)
            _Demencia_Aparicion_Incontinencia = Value
        End Set
    End Property

    Public Property Demencia_Incapacidad_Hablar() As Integer
        Get
            Return _Demencia_Incapacidad_Hablar
        End Get
        Set(ByVal Value As Integer)
            _Demencia_Incapacidad_Hablar = Value
        End Set
    End Property

    Public Property Demencia_Perdida() As Integer
        Get
            Return _Demencia_Perdida
        End Get
        Set(ByVal Value As Integer)
            _Demencia_Perdida = Value
        End Set
    End Property

    Public Property Demencia_Aparicion_Dificultad() As Integer
        Get
            Return _Demencia_Aparicion_Dificultad
        End Get
        Set(ByVal Value As Integer)
            _Demencia_Aparicion_Dificultad = Value
        End Set
    End Property

    Public Property Demencia_Multiples() As Integer
        Get
            Return _Demencia_Multiples
        End Get
        Set(ByVal Value As Integer)
            _Demencia_Multiples = Value
        End Set
    End Property

    Public Property Cumple_Demencia() As Integer
        Get
            Return _Cumple_Demencia
        End Get
        Set(ByVal Value As Integer)
            _Cumple_Demencia = Value
        End Set
    End Property

    Public Property Parkinson_Deterioro() As Integer
        Get
            Return _Parkinson_Deterioro
        End Get
        Set(ByVal Value As Integer)
            _Parkinson_Deterioro = Value
        End Set
    End Property

    Public Property Parkinson_Sintomas() As Integer
        Get
            Return _Parkinson_Sintomas
        End Get
        Set(ByVal Value As Integer)
            _Parkinson_Sintomas = Value
        End Set
    End Property

    Public Property Parkinson_Problemas() As Integer
        Get
            Return _Parkinson_Problemas
        End Get
        Set(ByVal Value As Integer)
            _Parkinson_Problemas = Value
        End Set
    End Property

    Public Property Parkinson_Disfagia() As Integer
        Get
            Return _Parkinson_Disfagia
        End Get
        Set(ByVal Value As Integer)
            _Parkinson_Disfagia = Value
        End Set
    End Property

    Public Property Parkinson_Neumonia() As Integer
        Get
            Return _Parkinson_Neumonia
        End Get
        Set(ByVal Value As Integer)
            _Parkinson_Neumonia = Value
        End Set
    End Property

    Public Property Parkinson_Cumple() As Integer
        Get
            Return _Parkinson_Cumple
        End Get
        Set(ByVal Value As Integer)
            _Parkinson_Cumple = Value
        End Set
    End Property

    Public Property Motoneurona_Deterioro() As Integer
        Get
            Return _Motoneurona_Deterioro
        End Get
        Set(ByVal Value As Integer)
            _Motoneurona_Deterioro = Value
        End Set
    End Property

    Public Property Motoneurona_Sintomas() As Integer
        Get
            Return _Motoneurona_Sintomas
        End Get
        Set(ByVal Value As Integer)
            _Motoneurona_Sintomas = Value
        End Set
    End Property

    Public Property Motoneurona_Problemas() As Integer
        Get
            Return _Motoneurona_Problemas
        End Get
        Set(ByVal Value As Integer)
            _Motoneurona_Problemas = Value
        End Set
    End Property

    Public Property Motoneurona_Disfagia() As Integer
        Get
            Return _Motoneurona_Disfagia
        End Get
        Set(ByVal Value As Integer)
            _Motoneurona_Disfagia = Value
        End Set
    End Property

    Public Property Motoneurona_Neumonia() As Integer
        Get
            Return _Motoneurona_Neumonia
        End Get
        Set(ByVal Value As Integer)
            _Motoneurona_Neumonia = Value
        End Set
    End Property

    Public Property Motoneurona_Cumple() As Integer
        Get
            Return _Motoneurona_Cumple
        End Get
        Set(ByVal Value As Integer)
            _Motoneurona_Cumple = Value
        End Set
    End Property

    Public Property Esclerosis_Multiple_Deterioro() As Integer
        Get
            Return _Esclerosis_Multiple_Deterioro
        End Get
        Set(ByVal Value As Integer)
            _Esclerosis_Multiple_Deterioro = Value
        End Set
    End Property

    Public Property Esclerosis_Multiple_Sintomas() As Integer
        Get
            Return _Esclerosis_Multiple_Sintomas
        End Get
        Set(ByVal Value As Integer)
            _Esclerosis_Multiple_Sintomas = Value
        End Set
    End Property

    Public Property Esclerosis_Multiple_Problemas() As Integer
        Get
            Return _Esclerosis_Multiple_Problemas
        End Get
        Set(ByVal Value As Integer)
            _Esclerosis_Multiple_Problemas = Value
        End Set
    End Property

    Public Property Esclerosis_Multiple_Disfagia() As Integer
        Get
            Return _Esclerosis_Multiple_Disfagia
        End Get
        Set(ByVal Value As Integer)
            _Esclerosis_Multiple_Disfagia = Value
        End Set
    End Property

    Public Property Esclerosis_Multiple_Neumonia() As Integer
        Get
            Return _Esclerosis_Multiple_Neumonia
        End Get
        Set(ByVal Value As Integer)
            _Esclerosis_Multiple_Neumonia = Value
        End Set
    End Property

    Public Property Esclerosis_Multiple_Cumple() As Integer
        Get
            Return _Esclerosis_Multiple_Cumple
        End Get
        Set(ByVal Value As Integer)
            _Esclerosis_Multiple_Cumple = Value
        End Set
    End Property

    Public Property Cardiaca_Cronica_Insuficiencia_Cardiaca() As Integer
        Get
            Return _Cardiaca_Cronica_Insuficiencia_Cardiaca
        End Get
        Set(ByVal Value As Integer)
            _Cardiaca_Cronica_Insuficiencia_Cardiaca = Value
        End Set
    End Property

    Public Property Cardiaca_Cronica_Disnea() As Integer
        Get
            Return _Cardiaca_Cronica_Disnea
        End Get
        Set(ByVal Value As Integer)
            _Cardiaca_Cronica_Disnea = Value
        End Set
    End Property

    Public Property Cardiaca_Cronica_Sintomas() As Integer
        Get
            Return _Cardiaca_Cronica_Sintomas
        End Get
        Set(ByVal Value As Integer)
            _Cardiaca_Cronica_Sintomas = Value
        End Set
    End Property

    Public Property Cardiaca_Cronica_Ecocardiograma() As Integer
        Get
            Return _Cardiaca_Cronica_Ecocardiograma
        End Get
        Set(ByVal Value As Integer)
            _Cardiaca_Cronica_Ecocardiograma = Value
        End Set
    End Property

    Public Property Cardiaca_Cronica_Insuficiencia_Renal() As Integer
        Get
            Return _Cardiaca_Cronica_Insuficiencia_Renal
        End Get
        Set(ByVal Value As Integer)
            _Cardiaca_Cronica_Insuficiencia_Renal = Value
        End Set
    End Property

    Public Property Cardiaca_Cronica_Ingresos() As Integer
        Get
            Return _Cardiaca_Cronica_Ingresos
        End Get
        Set(ByVal Value As Integer)
            _Cardiaca_Cronica_Ingresos = Value
        End Set
    End Property

    Public Property Cardiaca_Cronica_Cumple() As Integer
        Get
            Return _Cardiaca_Cronica_Cumple
        End Get
        Set(ByVal Value As Integer)
            _Cardiaca_Cronica_Cumple = Value
        End Set
    End Property

    Public Property Cerebro_Vascular_Cumple_Fragilidad() As Integer
        Get
            Return _Cerebro_Vascular_Cumple_Fragilidad
        End Get
        Set(ByVal Value As Integer)
            _Cerebro_Vascular_Cumple_Fragilidad = Value
        End Set
    End Property

    Public Property Cerebro_Vascular_Aprobado() As Integer
        Get
            Return _Cerebro_Vascular_Aprobado
        End Get
        Set(ByVal Value As Integer)
            _Cerebro_Vascular_Aprobado = Value
        End Set
    End Property

    Public Property Cerebro_Vascular_Cumple() As Integer
        Get
            Return _Cerebro_Vascular_Cumple
        End Get
        Set(ByVal Value As Integer)
            _Cerebro_Vascular_Cumple = Value
        End Set
    End Property

    Public Property Pulmonar_Cronica_Disnea() As Integer
        Get
            Return _Pulmonar_Cronica_Disnea
        End Get
        Set(ByVal Value As Integer)
            _Pulmonar_Cronica_Disnea = Value
        End Set
    End Property

    Public Property Pulmonar_Cronica_Sintomas() As Integer
        Get
            Return _Pulmonar_Cronica_Sintomas
        End Get
        Set(ByVal Value As Integer)
            _Pulmonar_Cronica_Sintomas = Value
        End Set
    End Property

    Public Property Pulmonar_Cronica_Criterios() As Integer
        Get
            Return _Pulmonar_Cronica_Criterios
        End Get
        Set(ByVal Value As Integer)
            _Pulmonar_Cronica_Criterios = Value
        End Set
    End Property

    Public Property Pulmonar_Cronica_En() As Integer
        Get
            Return _Pulmonar_Cronica_En
        End Get
        Set(ByVal Value As Integer)
            _Pulmonar_Cronica_En = Value
        End Set
    End Property

    Public Property Pulmonar_Cronica_Insuficiencia() As Integer
        Get
            Return _Pulmonar_Cronica_Insuficiencia
        End Get
        Set(ByVal Value As Integer)
            _Pulmonar_Cronica_Insuficiencia = Value
        End Set
    End Property

    Public Property Pulmonar_Cronica_Ingresos() As Integer
        Get
            Return _Pulmonar_Cronica_Ingresos
        End Get
        Set(ByVal Value As Integer)
            _Pulmonar_Cronica_Ingresos = Value
        End Set
    End Property

    Public Property Pulmonar_Cronica_Cumple() As Integer
        Get
            Return _Pulmonar_Cronica_Cumple
        End Get
        Set(ByVal Value As Integer)
            _Pulmonar_Cronica_Cumple = Value
        End Set
    End Property

    Public Property Hepatica_Cronica_Cirrosis() As Integer
        Get
            Return _Hepatica_Cronica_Cirrosis
        End Get
        Set(ByVal Value As Integer)
            _Hepatica_Cronica_Cirrosis = Value
        End Set
    End Property

    Public Property Hepatica_Cronica_Puntuacion() As Integer
        Get
            Return _Hepatica_Cronica_Puntuacion
        End Get
        Set(ByVal Value As Integer)
            _Hepatica_Cronica_Puntuacion = Value
        End Set
    End Property

    Public Property Hepatica_Cronica_Presencia() As Integer
        Get
            Return _Hepatica_Cronica_Presencia
        End Get
        Set(ByVal Value As Integer)
            _Hepatica_Cronica_Presencia = Value
        End Set
    End Property

    Public Property Hepatica_Cronica_Carcinoma() As Integer
        Get
            Return _Hepatica_Cronica_Carcinoma
        End Get
        Set(ByVal Value As Integer)
            _Hepatica_Cronica_Carcinoma = Value
        End Set
    End Property

    Public Property Hepatica_Cronica_Cumple() As Integer
        Get
            Return _Hepatica_Cronica_Cumple
        End Get
        Set(ByVal Value As Integer)
            _Hepatica_Cronica_Cumple = Value
        End Set
    End Property

    Public Property Renal_Cronica_Insuficiencia() As Integer
        Get
            Return _Renal_Cronica_Insuficiencia
        End Get
        Set(ByVal Value As Integer)
            _Renal_Cronica_Insuficiencia = Value
        End Set
    End Property

    'WACHV, INICIO, 19SEPT2017, Nuevas preguntas
    Public Property Renal_Cronica_CriterioFragilidadSevera() As Integer
        Get
            Return _Renal_Cronica_CriterioFragilidadSevera
        End Get
        Set(ByVal Value As Integer)
            _Renal_Cronica_CriterioFragilidadSevera = Value
        End Set
    End Property

    Public Property Renal_Cronica_AprobadoJuntaPaliativa() As Integer
        Get
            Return _Renal_Cronica_AprobadoJuntaPaliativa
        End Get
        Set(ByVal Value As Integer)
            _Renal_Cronica_AprobadoJuntaPaliativa = Value
        End Set
    End Property
    'WACHV, FIN, 19SEPT2017, Nuevas preguntas

    Public Property Renal_Cronica_Cumple() As Integer
        Get
            Return _Renal_Cronica_Cumple
        End Get
        Set(ByVal Value As Integer)
            _Renal_Cronica_Cumple = Value
        End Set
    End Property

    Public Property Fragilidad_Severa_Deterioro() As Integer
        Get
            Return _Fragilidad_Severa_Deterioro
        End Get
        Set(ByVal Value As Integer)
            _Fragilidad_Severa_Deterioro = Value
        End Set
    End Property

    Public Property Fragilidad_Severa_Perdida_Peso() As Integer
        Get
            Return _Fragilidad_Severa_Perdida_Peso
        End Get
        Set(ByVal Value As Integer)
            _Fragilidad_Severa_Perdida_Peso = Value
        End Set
    End Property

    Public Property Fragilidad_Severa_Albumina() As Integer
        Get
            Return _Fragilidad_Severa_Albumina
        End Get
        Set(ByVal Value As Integer)
            _Fragilidad_Severa_Albumina = Value
        End Set
    End Property

    Public Property Fragilidad_Severa_Impresion() As Integer
        Get
            Return _Fragilidad_Severa_Impresion
        End Get
        Set(ByVal Value As Integer)
            _Fragilidad_Severa_Impresion = Value
        End Set
    End Property

    Public Property Fragilidad_Severa_Barthel() As Integer
        Get
            Return _Fragilidad_Severa_Barthel
        End Get
        Set(ByVal Value As Integer)
            _Fragilidad_Severa_Barthel = Value
        End Set
    End Property

    Public Property Fragilidad_Severa_Pps() As Integer
        Get
            Return _Fragilidad_Severa_Pps
        End Get
        Set(ByVal Value As Integer)
            _Fragilidad_Severa_Pps = Value
        End Set
    End Property

    Public Property Fragilidad_Severa_Perdida_Actividades() As Integer
        Get
            Return _Fragilidad_Severa_Perdida_Actividades
        End Get
        Set(ByVal Value As Integer)
            _Fragilidad_Severa_Perdida_Actividades = Value
        End Set
    End Property

    Public Property Fragilidad_Severa_Ulceras() As Integer
        Get
            Return _Fragilidad_Severa_Ulceras
        End Get
        Set(ByVal Value As Integer)
            _Fragilidad_Severa_Ulceras = Value
        End Set
    End Property

    Public Property Fragilidad_Severa_Infecciones() As Integer
        Get
            Return _Fragilidad_Severa_Infecciones
        End Get
        Set(ByVal Value As Integer)
            _Fragilidad_Severa_Infecciones = Value
        End Set
    End Property

    Public Property Fragilidad_Severa_Delirium() As Integer
        Get
            Return _Fragilidad_Severa_Delirium
        End Get
        Set(ByVal Value As Integer)
            _Fragilidad_Severa_Delirium = Value
        End Set
    End Property

    Public Property Fragilidad_Severa_Disfagia() As Integer
        Get
            Return _Fragilidad_Severa_Disfagia
        End Get
        Set(ByVal Value As Integer)
            _Fragilidad_Severa_Disfagia = Value
        End Set
    End Property

    Public Property Fragilidad_Severa_Caidas() As Integer
        Get
            Return _Fragilidad_Severa_Caidas
        End Get
        Set(ByVal Value As Integer)
            _Fragilidad_Severa_Caidas = Value
        End Set
    End Property

    Public Property Fragilidad_Severa_Sintomas() As Integer
        Get
            Return _Fragilidad_Severa_Sintomas
        End Get
        Set(ByVal Value As Integer)
            _Fragilidad_Severa_Sintomas = Value
        End Set
    End Property

    Public Property Fragilidad_Severa_Mas_Ingresos() As Integer
        Get
            Return _Fragilidad_Severa_Mas_Ingresos
        End Get
        Set(ByVal Value As Integer)
            _Fragilidad_Severa_Mas_Ingresos = Value
        End Set
    End Property

    Public Property Fragilidad_Severa_Necesidad() As Integer
        Get
            Return _Fragilidad_Severa_Necesidad
        End Get
        Set(ByVal Value As Integer)
            _Fragilidad_Severa_Necesidad = Value
        End Set
    End Property

    Public Property Fragilidad_Severa_Mas_Patologias() As Integer
        Get
            Return _Fragilidad_Severa_Mas_Patologias
        End Get
        Set(ByVal Value As Integer)
            _Fragilidad_Severa_Mas_Patologias = Value
        End Set
    End Property

    Public Property Fragilidad_Severa_Cumple() As Integer
        Get
            Return _Fragilidad_Severa_Cumple
        End Get
        Set(ByVal Value As Integer)
            _Fragilidad_Severa_Cumple = Value
        End Set
    End Property

    Public Property fec_con() As DateTime
        Get
            Return _fec_con
        End Get
        Set(ByVal Value As DateTime)
            _fec_con = Value
        End Set
    End Property

    Public Property obs() As String
        Get
            Return _obs
        End Get
        Set(ByVal Value As String)
            _obs = Value
        End Set
    End Property

    Public Property login() As String
        Get
            Return _login
        End Get
        Set(ByVal Value As String)
            _login = Value
        End Set
    End Property

    Private lstPreguntasCritIngreso As List(Of PreguntaCP)

#End Region

#Region "Functions"

    ''' <summary>
    ''' Guarda el Criterio de Ingreso
    ''' </summary>
    ''' <param name="oCriterioIngreso">Criterio de Ingreso a guardar</param>
    ''' <returns>Resultado de la inserción</returns>
    ''' <remarks></remarks>
    Public Function GuardarCriterioIngreso(ByVal oCriterioIngreso As CriterioIngreso) As String
        Dim objDACPCriterioIngreso As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
        Return objDACPCriterioIngreso.GuardarCriterioIngreso(oCriterioIngreso)
    End Function

    ''' <summary>
    ''' Consulta las preguntas que corresponden al criterio de ingreso
    ''' </summary>
    ''' <param name="oPreguntaCP">Criterio de ingreso que contiene los filtros de búsqueda</param>
    ''' <returns>Listado de Preguntas</returns>
    ''' <remarks></remarks>
    Private Function ConsultarPreguntas(ByVal oPreguntaCP As PreguntaCP) As List(Of PreguntaCP)
        Dim objDAPreguntaCP As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
        oPreguntaCP.seccion = Me.SeccionCriterioIngreso
        Return objDAPreguntaCP.ConsultarPreguntas(oPreguntaCP)
    End Function

    ''' <summary>
    ''' Obtiene la ultima respuesta en forma del objeto de criterios de ingreso.
    ''' </summary>
    ''' <param name="id_Pregunta">Id de la pregunta obtenida del servicio de última respuesta</param>
    ''' <param name="Respuesta">Respuesta de la pregunta obtenida del servicio de última respuesta</param>
    ''' <returns>El criterio ingreso con la respuesta obtenida por el servicio de última respuesta</returns>
    ''' <remarks></remarks>
    Private Function ObtenerUltimaRespuesta(ByVal id_Pregunta As Integer, ByVal Respuesta As String) As CriterioIngreso
        Dim objDACPCriterioIngreso As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
        Return objDACPCriterioIngreso.ConsultarURCriterioIngreso(id_Pregunta, Respuesta)
    End Function

    ''' <summary>
    ''' Obtiene la respuesta del servicio de ultimas respuestas.
    ''' </summary>
    ''' <param name="objGeneral"></param>
    ''' <param name="objPaciente"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SugerirRespuesta(ByVal objGeneral As Generales, ByVal objPaciente As Paciente) As CriterioIngreso

        Dim oURCriterioIngreso As New CriterioIngreso()
        Dim srvCriterioIngreso As New CuidadosPaleativosServiceImpService()
        Dim oCriterioIngreso As New CriterioIngreso()

        Try
            lstPreguntasCritIngreso = ConsultarPreguntas(New PreguntaCP)

            If lstPreguntasCritIngreso.Count > 0 Then
                Dim aPreUltRespuesta(lstPreguntasCritIngreso.Count) As Long
                Dim aUltimaRespuesta(lstPreguntasCritIngreso.Count) As PreguntaType
                Dim DAOCP As New DAOCuidadosPaliativos()
                Dim Resultado As String
                Dim appOrigen As String = objPaciente.AppOrigenCP.ToUpper()

                srvCriterioIngreso.Url = DAOCP.ConsultarUrlServicioUT(objGeneral.Prestador, objGeneral.Sucursal, DAOCP.TipoServicio, DAOCP.MetodoServicio)

                If srvCriterioIngreso.Url = "" Then
                    Throw New Exception("No fue posible consultar el servicio de últimas respuestas (URL)")
                End If

                For i As Integer = 0 To lstPreguntasCritIngreso.Count - 1
                    aPreUltRespuesta(i) = lstPreguntasCritIngreso.Item(i).id
                Next

                ''WACHV, 22Dic2017, Se agrega Obtener la ref regional en cada Bd
                '', se cambia parametro de regional objPaciente.Ciudad.ToUpper() por lo retornado en strRegionalRefBD
                Dim strRegionalRefBD As String = DAOCP.ConsultarRegional()
                Resultado = srvCriterioIngreso.ultimasRespuestas(objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                aPreUltRespuesta, appOrigen, strRegionalRefBD.ToUpper(), aUltimaRespuesta)

                For Each pr As PreguntaType In aUltimaRespuesta
                    'If pr.respuestas.textoRespuesta <> Nothing Then
                    '    oCriterioIngreso = ObtenerUltimaRespuesta(pr.idPregunta, pr.respuestas.textoRespuesta)
                    '    CargarUltimaRespuesta(oCriterioIngreso, oURCriterioIngreso)
                    'End If
                    If Not pr.respuestas.listadoIdRespuesta Is Nothing Then
                        If pr.respuestas.listadoIdRespuesta.Length > 0 Then
                            For i As Integer = 0 To pr.respuestas.listadoIdRespuesta.Length - 1
                                oCriterioIngreso = ObtenerUltimaRespuesta(pr.idPregunta, pr.respuestas.listadoIdRespuesta(i).ToString())
                                CargarUltimaRespuesta(oCriterioIngreso, oURCriterioIngreso)
                            Next
                        End If
                    End If
                Next
            End If
            Return oURCriterioIngreso
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Carga el objeto de ultima respuesta que se devuelve al control
    ''' </summary>
    ''' <param name="oCriterioIngreso">Criterio Ingreso</param>
    ''' <param name="oURCriterioIngreso">Última Respuesta Criterio Ingreso</param>
    ''' <remarks></remarks>
    Private Sub CargarUltimaRespuesta(ByVal oCriterioIngreso As CriterioIngreso, ByRef oURCriterioIngreso As CriterioIngreso)
        Try
            If oCriterioIngreso.Oncologica_Diagnostico <> 0 Then
                oURCriterioIngreso.Oncologica_Diagnostico = oCriterioIngreso.Oncologica_Diagnostico
            End If

            If oCriterioIngreso.Oncologica_Deterioro <> 0 Then
                oURCriterioIngreso.Oncologica_Deterioro = oCriterioIngreso.Oncologica_Deterioro
            End If

            If oCriterioIngreso.Oncologica_Sintomas <> 0 Then
                oURCriterioIngreso.Oncologica_Sintomas = oCriterioIngreso.Oncologica_Sintomas
            End If

            'If oCriterioIngreso.Oncologica_Cumple <> 0 Then
            '    oURCriterioIngreso.Oncologica_Cumple = oCriterioIngreso.Oncologica_Cumple
            'End If

            If oCriterioIngreso.VIHSIDA_Criterio <> 0 Then
                oURCriterioIngreso.VIHSIDA_Criterio = oCriterioIngreso.VIHSIDA_Criterio
            End If

            If oCriterioIngreso.VIHSIDA_Aprobado <> 0 Then
                oURCriterioIngreso.VIHSIDA_Aprobado = oCriterioIngreso.VIHSIDA_Aprobado
            End If

            'If oCriterioIngreso.VIHSIDA_Cumple <> 0 Then
            '    oURCriterioIngreso.VIHSIDA_Cumple = oCriterioIngreso.VIHSIDA_Cumple
            'End If

            If oCriterioIngreso.Demencia_Incapacidad_Vestirse <> 0 Then
                oURCriterioIngreso.Demencia_Incapacidad_Vestirse = oCriterioIngreso.Demencia_Incapacidad_Vestirse
            End If

            If oCriterioIngreso.Demencia_Aparicion_Incontinencia <> 0 Then
                oURCriterioIngreso.Demencia_Aparicion_Incontinencia = oCriterioIngreso.Demencia_Aparicion_Incontinencia
            End If

            If oCriterioIngreso.Demencia_Incapacidad_Hablar <> 0 Then
                oURCriterioIngreso.Demencia_Incapacidad_Hablar = oCriterioIngreso.Demencia_Incapacidad_Hablar
            End If

            If oCriterioIngreso.Demencia_Perdida <> 0 Then
                oURCriterioIngreso.Demencia_Perdida = oCriterioIngreso.Demencia_Perdida
            End If

            If oCriterioIngreso.Demencia_Aparicion_Dificultad <> 0 Then
                oURCriterioIngreso.Demencia_Aparicion_Dificultad = oCriterioIngreso.Demencia_Aparicion_Dificultad
            End If

            If oCriterioIngreso.Demencia_Multiples <> 0 Then
                oURCriterioIngreso.Demencia_Multiples = oCriterioIngreso.Demencia_Multiples
            End If

            'If oCriterioIngreso.Cumple_Demencia <> 0 Then
            '    oURCriterioIngreso.Cumple_Demencia = oCriterioIngreso.Cumple_Demencia
            'End If

            If oCriterioIngreso.Parkinson_Deterioro <> 0 Then
                oURCriterioIngreso.Parkinson_Deterioro = oCriterioIngreso.Parkinson_Deterioro
            End If

            If oCriterioIngreso.Parkinson_Sintomas <> 0 Then
                oURCriterioIngreso.Parkinson_Sintomas = oCriterioIngreso.Parkinson_Sintomas
            End If

            If oCriterioIngreso.Parkinson_Problemas <> 0 Then
                oURCriterioIngreso.Parkinson_Problemas = oCriterioIngreso.Parkinson_Problemas
            End If

            If oCriterioIngreso.Parkinson_Disfagia <> 0 Then
                oURCriterioIngreso.Parkinson_Disfagia = oCriterioIngreso.Parkinson_Disfagia
            End If

            If oCriterioIngreso.Parkinson_Neumonia <> 0 Then
                oURCriterioIngreso.Parkinson_Neumonia = oCriterioIngreso.Parkinson_Neumonia
            End If

            'If oCriterioIngreso.Parkinson_Cumple <> 0 Then
            '    oURCriterioIngreso.Parkinson_Cumple = oCriterioIngreso.Parkinson_Cumple
            'End If

            If oCriterioIngreso.Motoneurona_Deterioro <> 0 Then
                oURCriterioIngreso.Motoneurona_Deterioro = oCriterioIngreso.Motoneurona_Deterioro
            End If

            If oCriterioIngreso.Motoneurona_Sintomas <> 0 Then
                oURCriterioIngreso.Motoneurona_Sintomas = oCriterioIngreso.Motoneurona_Sintomas
            End If

            If oCriterioIngreso.Motoneurona_Problemas <> 0 Then
                oURCriterioIngreso.Motoneurona_Problemas = oCriterioIngreso.Motoneurona_Problemas
            End If

            If oCriterioIngreso.Motoneurona_Disfagia <> 0 Then
                oURCriterioIngreso.Motoneurona_Disfagia = oCriterioIngreso.Motoneurona_Disfagia
            End If

            If oCriterioIngreso.Motoneurona_Neumonia <> 0 Then
                oURCriterioIngreso.Motoneurona_Neumonia = oCriterioIngreso.Motoneurona_Neumonia
            End If

            'If oCriterioIngreso.Motoneurona_Cumple <> 0 Then
            '    oURCriterioIngreso.Motoneurona_Cumple = oCriterioIngreso.Motoneurona_Cumple
            'End If

            If oCriterioIngreso.Esclerosis_Multiple_Deterioro <> 0 Then
                oURCriterioIngreso.Esclerosis_Multiple_Deterioro = oCriterioIngreso.Esclerosis_Multiple_Deterioro
            End If

            If oCriterioIngreso.Esclerosis_Multiple_Sintomas <> 0 Then
                oURCriterioIngreso.Esclerosis_Multiple_Sintomas = oCriterioIngreso.Esclerosis_Multiple_Sintomas
            End If

            If oCriterioIngreso.Esclerosis_Multiple_Problemas <> 0 Then
                oURCriterioIngreso.Esclerosis_Multiple_Problemas = oCriterioIngreso.Esclerosis_Multiple_Problemas
            End If

            If oCriterioIngreso.Esclerosis_Multiple_Disfagia <> 0 Then
                oURCriterioIngreso.Esclerosis_Multiple_Disfagia = oCriterioIngreso.Esclerosis_Multiple_Disfagia
            End If

            If oCriterioIngreso.Esclerosis_Multiple_Neumonia <> 0 Then
                oURCriterioIngreso.Esclerosis_Multiple_Neumonia = oCriterioIngreso.Esclerosis_Multiple_Neumonia
            End If

            'If oCriterioIngreso.Esclerosis_Multiple_Cumple <> 0 Then
            '    oURCriterioIngreso.Esclerosis_Multiple_Cumple = oCriterioIngreso.Esclerosis_Multiple_Cumple
            'End If

            If oCriterioIngreso.Cardiaca_Cronica_Insuficiencia_Cardiaca <> 0 Then
                oURCriterioIngreso.Cardiaca_Cronica_Insuficiencia_Cardiaca = oCriterioIngreso.Cardiaca_Cronica_Insuficiencia_Cardiaca
            End If

            If oCriterioIngreso.Cardiaca_Cronica_Disnea <> 0 Then
                oURCriterioIngreso.Cardiaca_Cronica_Disnea = oCriterioIngreso.Cardiaca_Cronica_Disnea
            End If

            If oCriterioIngreso.Cardiaca_Cronica_Sintomas <> 0 Then
                oURCriterioIngreso.Cardiaca_Cronica_Sintomas = oCriterioIngreso.Cardiaca_Cronica_Sintomas
            End If

            If oCriterioIngreso.Cardiaca_Cronica_Ecocardiograma <> 0 Then
                oURCriterioIngreso.Cardiaca_Cronica_Ecocardiograma = oCriterioIngreso.Cardiaca_Cronica_Ecocardiograma
            End If

            If oCriterioIngreso.Cardiaca_Cronica_Insuficiencia_Renal <> 0 Then
                oURCriterioIngreso.Cardiaca_Cronica_Insuficiencia_Renal = oCriterioIngreso.Cardiaca_Cronica_Insuficiencia_Renal
            End If

            If oCriterioIngreso.Cardiaca_Cronica_Ingresos <> 0 Then
                oURCriterioIngreso.Cardiaca_Cronica_Ingresos = oCriterioIngreso.Cardiaca_Cronica_Ingresos
            End If

            'If oCriterioIngreso.Cardiaca_Cronica_Cumple <> 0 Then
            '    oURCriterioIngreso.Cardiaca_Cronica_Cumple = oCriterioIngreso.Cardiaca_Cronica_Cumple
            'End If

            If oCriterioIngreso.Cerebro_Vascular_Cumple_Fragilidad <> 0 Then
                oURCriterioIngreso.Cerebro_Vascular_Cumple_Fragilidad = oCriterioIngreso.Cerebro_Vascular_Cumple_Fragilidad
            End If

            If oCriterioIngreso.Cerebro_Vascular_Aprobado <> 0 Then
                oURCriterioIngreso.Cerebro_Vascular_Aprobado = oCriterioIngreso.Cerebro_Vascular_Aprobado
            End If

            'If oCriterioIngreso.Cerebro_Vascular_Cumple <> 0 Then
            '    oURCriterioIngreso.Cerebro_Vascular_Cumple = oCriterioIngreso.Cerebro_Vascular_Cumple
            'End If

            If oCriterioIngreso.Pulmonar_Cronica_Disnea <> 0 Then
                oURCriterioIngreso.Pulmonar_Cronica_Disnea = oCriterioIngreso.Pulmonar_Cronica_Disnea
            End If

            If oCriterioIngreso.Pulmonar_Cronica_Sintomas <> 0 Then
                oURCriterioIngreso.Pulmonar_Cronica_Sintomas = oCriterioIngreso.Pulmonar_Cronica_Sintomas
            End If

            If oCriterioIngreso.Pulmonar_Cronica_Criterios <> 0 Then
                oURCriterioIngreso.Pulmonar_Cronica_Criterios = oCriterioIngreso.Pulmonar_Cronica_Criterios
            End If

            If oCriterioIngreso.Pulmonar_Cronica_En <> 0 Then
                oURCriterioIngreso.Pulmonar_Cronica_En = oCriterioIngreso.Pulmonar_Cronica_En
            End If

            If oCriterioIngreso.Pulmonar_Cronica_Insuficiencia <> 0 Then
                oURCriterioIngreso.Pulmonar_Cronica_Insuficiencia = oCriterioIngreso.Pulmonar_Cronica_Insuficiencia
            End If

            If oCriterioIngreso.Pulmonar_Cronica_Ingresos <> 0 Then
                oURCriterioIngreso.Pulmonar_Cronica_Ingresos = oCriterioIngreso.Pulmonar_Cronica_Ingresos
            End If

            'If oCriterioIngreso.Pulmonar_Cronica_Cumple <> 0 Then
            '    oURCriterioIngreso.Pulmonar_Cronica_Cumple = oCriterioIngreso.Pulmonar_Cronica_Cumple
            'End If

            If oCriterioIngreso.Hepatica_Cronica_Cirrosis <> 0 Then
                oURCriterioIngreso.Hepatica_Cronica_Cirrosis = oCriterioIngreso.Hepatica_Cronica_Cirrosis
            End If

            If oCriterioIngreso.Hepatica_Cronica_Puntuacion <> 0 Then
                oURCriterioIngreso.Hepatica_Cronica_Puntuacion = oCriterioIngreso.Hepatica_Cronica_Puntuacion
            End If

            If oCriterioIngreso.Hepatica_Cronica_Presencia <> 0 Then
                oURCriterioIngreso.Hepatica_Cronica_Presencia = oCriterioIngreso.Hepatica_Cronica_Presencia
            End If

            If oCriterioIngreso.Hepatica_Cronica_Carcinoma <> 0 Then
                oURCriterioIngreso.Hepatica_Cronica_Carcinoma = oCriterioIngreso.Hepatica_Cronica_Carcinoma
            End If

            'If oCriterioIngreso.Hepatica_Cronica_Cumple <> 0 Then
            '    oURCriterioIngreso.Hepatica_Cronica_Cumple = oCriterioIngreso.Hepatica_Cronica_Cumple
            'End If

            If oCriterioIngreso.Renal_Cronica_Insuficiencia <> 0 Then
                oURCriterioIngreso.Renal_Cronica_Insuficiencia = oCriterioIngreso.Renal_Cronica_Insuficiencia
            End If

            ''WACHV,13OCT2017 INICIO, NUEVAS PREGUNTAS 
            If oCriterioIngreso.Renal_Cronica_CriterioFragilidadSevera <> 0 Then
                oURCriterioIngreso.Renal_Cronica_CriterioFragilidadSevera = oCriterioIngreso.Renal_Cronica_CriterioFragilidadSevera
            End If

            If oCriterioIngreso.Renal_Cronica_AprobadoJuntaPaliativa <> 0 Then
                oURCriterioIngreso.Renal_Cronica_AprobadoJuntaPaliativa = oCriterioIngreso.Renal_Cronica_AprobadoJuntaPaliativa
            End If

            ''WACHV,13OCT2017 FIN, NUEVAS PREGUNTAS 

            'If oCriterioIngreso.Renal_Cronica_Cumple <> 0 Then
            '    oURCriterioIngreso.Renal_Cronica_Cumple = oCriterioIngreso.Renal_Cronica_Cumple
            'End If

            If oCriterioIngreso.Fragilidad_Severa_Deterioro <> 0 Then
                oURCriterioIngreso.Fragilidad_Severa_Deterioro = oCriterioIngreso.Fragilidad_Severa_Deterioro
            End If

            If oCriterioIngreso.Fragilidad_Severa_Perdida_Peso <> 0 Then
                oURCriterioIngreso.Fragilidad_Severa_Perdida_Peso = oCriterioIngreso.Fragilidad_Severa_Perdida_Peso
            End If

            If oCriterioIngreso.Fragilidad_Severa_Albumina <> 0 Then
                oURCriterioIngreso.Fragilidad_Severa_Albumina = oCriterioIngreso.Fragilidad_Severa_Albumina
            End If

            If oCriterioIngreso.Fragilidad_Severa_Impresion <> 0 Then
                oURCriterioIngreso.Fragilidad_Severa_Impresion = oCriterioIngreso.Fragilidad_Severa_Impresion
            End If

            If oCriterioIngreso.Fragilidad_Severa_Barthel <> 0 Then
                oURCriterioIngreso.Fragilidad_Severa_Barthel = oCriterioIngreso.Fragilidad_Severa_Barthel
            End If

            If oCriterioIngreso.Fragilidad_Severa_Pps <> 0 Then
                oURCriterioIngreso.Fragilidad_Severa_Pps = oCriterioIngreso.Fragilidad_Severa_Pps
            End If

            If oCriterioIngreso.Fragilidad_Severa_Perdida_Actividades <> 0 Then
                oURCriterioIngreso.Fragilidad_Severa_Perdida_Actividades = oCriterioIngreso.Fragilidad_Severa_Perdida_Actividades
            End If

            If oCriterioIngreso.Fragilidad_Severa_Ulceras <> 0 Then
                oURCriterioIngreso.Fragilidad_Severa_Ulceras = oCriterioIngreso.Fragilidad_Severa_Ulceras
            End If

            If oCriterioIngreso.Fragilidad_Severa_Infecciones <> 0 Then
                oURCriterioIngreso.Fragilidad_Severa_Infecciones = oCriterioIngreso.Fragilidad_Severa_Infecciones
            End If

            If oCriterioIngreso.Fragilidad_Severa_Delirium <> 0 Then
                oURCriterioIngreso.Fragilidad_Severa_Delirium = oCriterioIngreso.Fragilidad_Severa_Delirium
            End If

            If oCriterioIngreso.Fragilidad_Severa_Disfagia <> 0 Then
                oURCriterioIngreso.Fragilidad_Severa_Disfagia = oCriterioIngreso.Fragilidad_Severa_Disfagia
            End If

            If oCriterioIngreso.Fragilidad_Severa_Caidas <> 0 Then
                oURCriterioIngreso.Fragilidad_Severa_Caidas = oCriterioIngreso.Fragilidad_Severa_Caidas
            End If

            If oCriterioIngreso.Fragilidad_Severa_Sintomas <> 0 Then
                oURCriterioIngreso.Fragilidad_Severa_Sintomas = oCriterioIngreso.Fragilidad_Severa_Sintomas
            End If

            If oCriterioIngreso.Fragilidad_Severa_Mas_Ingresos <> 0 Then
                oURCriterioIngreso.Fragilidad_Severa_Mas_Ingresos = oCriterioIngreso.Fragilidad_Severa_Mas_Ingresos
            End If

            If oCriterioIngreso.Fragilidad_Severa_Necesidad <> 0 Then
                oURCriterioIngreso.Fragilidad_Severa_Necesidad = oCriterioIngreso.Fragilidad_Severa_Necesidad
            End If

            If oCriterioIngreso.Fragilidad_Severa_Mas_Patologias <> 0 Then
                oURCriterioIngreso.Fragilidad_Severa_Mas_Patologias = oCriterioIngreso.Fragilidad_Severa_Mas_Patologias
            End If

            'If oCriterioIngreso.Fragilidad_Severa_Cumple <> 0 Then
            '    oURCriterioIngreso.Fragilidad_Severa_Cumple = oCriterioIngreso.Fragilidad_Severa_Cumple
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

End Class
