Namespace Sophia.HistoriaClinica.HistoriaBasica
#Region "Clase Global Para Datos Historia Basica"
    Public Class DatosHistoriaBasica
        Implements IDisposable
#Region "Propiedades Clase Global Historia Basica"
        Private Shared _Instancia As DatosHistoriaBasica
        Public Shared ReadOnly Property Instancia() As DatosHistoriaBasica
            Get
                If _Instancia Is Nothing Then
                    _Instancia = New DatosHistoriaBasica
                End If
                Return _Instancia
            End Get
        End Property
        Private Sub New()

        End Sub
        Private _blnIniciada As Boolean = False
        Public Property Iniciada() As Boolean

            Get
                Return _blnIniciada
            End Get
            Set(ByVal Value As Boolean)
                _blnIniciada = Value
            End Set
        End Property
        Private _objMotivoDeConsulta As New cMotivoConsulta
        Public Property MotivoDeConsulta() As cMotivoConsulta
            Get
                Return _objMotivoDeConsulta
            End Get
            Set(ByVal Value As cMotivoConsulta)
                _objMotivoDeConsulta = Value
            End Set
        End Property

        Private _objAntecedentesPerinatales As New cAntecedentesPerinatales
        Public Property AntecedentesPerinatales() As cAntecedentesPerinatales
            Get
                Return _objAntecedentesPerinatales
            End Get
            Set(ByVal Value As cAntecedentesPerinatales)
                _objAntecedentesPerinatales = Value
            End Set
        End Property
        Private _objDesarrolloPsicomotor As New cDesarrolloPsicomotor
        Public Property DesarrolloPsicomotor() As cDesarrolloPsicomotor
            Get
                Return _objDesarrolloPsicomotor
            End Get
            Set(ByVal Value As cDesarrolloPsicomotor)
                _objDesarrolloPsicomotor = Value
            End Set
        End Property
        Private _objAntecedentesPatologicos As New cAntecedentesPatologicos
        Public Property AntecedentesPatologicos() As cAntecedentesPatologicos
            Get
                Return _objAntecedentesPatologicos
            End Get
            Set(ByVal Value As cAntecedentesPatologicos)
                _objAntecedentesPatologicos = Value
            End Set
        End Property
        Private _objAntecedentesGinecologicos As New cAntecedentesGinecologicos
        Public Property AntecedentesGinecologicos() As cAntecedentesGinecologicos
            Get
                Return _objAntecedentesGinecologicos
            End Get
            Set(ByVal Value As cAntecedentesGinecologicos)
                _objAntecedentesGinecologicos = Value
            End Set
        End Property
        Private _objAntecedentesQuirurgicos As New cAntecedentesQuirurgicos
        Public Property AntecedentesQuirurgicos() As cAntecedentesQuirurgicos
            Get
                Return _objAntecedentesQuirurgicos
            End Get
            Set(ByVal Value As cAntecedentesQuirurgicos)
                _objAntecedentesQuirurgicos = Value
            End Set
        End Property

        Private _objAntecedentesTransfusionales As New cAntecedentesTransfusionales
        Public Property AntecedentesTransfusionales() As cAntecedentesTransfusionales
            Get
                Return _objAntecedentesTransfusionales
            End Get
            Set(ByVal Value As cAntecedentesTransfusionales)
                _objAntecedentesTransfusionales = Value
            End Set
        End Property

        Private _objAntecedentesFarmacologicos As New cAntecedentesFarmacologicos
        Public Property AntecedentesFarmacologicos() As cAntecedentesFarmacologicos
            Get
                Return _objAntecedentesFarmacologicos
            End Get
            Set(ByVal Value As cAntecedentesFarmacologicos)
                _objAntecedentesFarmacologicos = Value
            End Set
        End Property
        'cdqf
        Private _objAntecedentesTrauma As New cAntecedentesTrauma
        Public Property AntecedentesTrauma() As cAntecedentesTrauma
            Get
                Return _objAntecedentesTrauma
            End Get
            Set(ByVal Value As cAntecedentesTrauma)
                _objAntecedentesTrauma = Value
            End Set
        End Property
        'cdqf
        Private _objAntecedentesAlergicos As New cAntecedentesAlergicos
        Public Property AntecedentesAlergicos() As cAntecedentesAlergicos
            Get
                Return _objAntecedentesAlergicos
            End Get
            Set(ByVal Value As cAntecedentesAlergicos)
                _objAntecedentesAlergicos = Value
            End Set
        End Property

        Private _objAnteccedentesToxicos As New cAntecedentesToxicos
        Public Property AntecedentesToxicos() As cAntecedentesToxicos
            Get
                Return _objAnteccedentesToxicos
            End Get
            Set(ByVal Value As cAntecedentesToxicos)
                _objAnteccedentesToxicos = Value
            End Set
        End Property

        Private _objAntecedentesFamiliares As New cAntecedentesFamiliares
        Public Property AntecedentesFamiliares() As cAntecedentesFamiliares
            Get
                Return _objAntecedentesFamiliares
            End Get
            Set(ByVal Value As cAntecedentesFamiliares)
                _objAntecedentesFamiliares = Value
            End Set
        End Property

        Private _objVacunas As New cVacunas
        Public Property Vacunas() As cVacunas
            Get
                Return _objVacunas
            End Get
            Set(ByVal Value As cVacunas)
                _objVacunas = Value
            End Set
        End Property

        Private _objExamenFisico As New cExamenFisico
        Public Property ExamenFisico() As cExamenFisico
            Get
                Return _objExamenFisico
            End Get
            Set(ByVal Value As cExamenFisico)
                _objExamenFisico = Value
            End Set
        End Property

        Private _objImpresionDiagnostica As New cImpresionDiagnostica
        Public Property ImpresionDiagnostica() As cImpresionDiagnostica
            Get
                Return _objImpresionDiagnostica
            End Get
            Set(ByVal Value As cImpresionDiagnostica)
                _objImpresionDiagnostica = Value
            End Set
        End Property

        Private _blnEstadoInstancia As Boolean = False
        Public Property EstadoInstancia() As Boolean
            Get
                Return _blnEstadoInstancia
            End Get
            Set(ByVal Value As Boolean)
                _blnEstadoInstancia = Value
            End Set
        End Property

        Private _strDatoPendienteModificar As String = ""
        Public Property StrDatoPendienteModificar() As String
            Get
                Return _strDatoPendienteModificar
            End Get
            Set(ByVal Value As String)
                _strDatoPendienteModificar = Value
            End Set
        End Property

        Private _blnTieneRegistros As Boolean = False
        Public Property TieneRegistros() As Boolean
            Get
                Return _blnTieneRegistros
            End Get
            Set(ByVal Value As Boolean)
                _blnTieneRegistros = Value
            End Set
        End Property

#End Region

#Region "SubClase Motivo de Consulta"
        Public Class cMotivoConsulta

            Private _strInformacionSuministradaPor As String = ""
            Public Property InformacionSuministradaPor() As String
                Get
                    Return _strInformacionSuministradaPor
                End Get
                Set(ByVal Value As String)
                    _strInformacionSuministradaPor = Value
                End Set
            End Property

            Private _blnInformacionSuministradaPor As Boolean = True
            Public Property HabilitarInformacionSuministradaPor() As Boolean
                Get
                    Return _blnInformacionSuministradaPor
                End Get
                Set(ByVal Value As Boolean)
                    _blnInformacionSuministradaPor = Value
                End Set
            End Property


            Private _strMotivoDeConsulta As String = ""
            Public Property MotivoDeConsulta() As String
                Get
                    Return _strMotivoDeConsulta
                End Get
                Set(ByVal Value As String)
                    _strMotivoDeConsulta = Value
                End Set
            End Property

            Private _blnMotivoDeConsulta As Boolean = True
            Public Property HabilitarMotivoDeConsulta() As Boolean
                Get
                    Return _blnMotivoDeConsulta
                End Get
                Set(ByVal Value As Boolean)
                    _blnMotivoDeConsulta = Value
                End Set
            End Property

            Private _strEnfermedadActual As String = ""
            Public Property EnfermedadActual() As String
                Get
                    Return _strEnfermedadActual
                End Get
                Set(ByVal Value As String)
                    _strEnfermedadActual = Value
                End Set
            End Property

            Private _blnEnfermedadActual As Boolean = True
            Public Property HabilitarEnfermedadActual() As Boolean
                Get
                    Return _blnEnfermedadActual
                End Get
                Set(ByVal Value As Boolean)
                    _blnEnfermedadActual = Value
                End Set
            End Property

            Private _dtRevisionPorSistemasMotivoConsulta As DataTable
            Public Property RevisionPorSistemasMotivoConsulta() As DataTable
                Get
                    Return _dtRevisionPorSistemasMotivoConsulta
                End Get
                Set(ByVal Value As DataTable)
                    _dtRevisionPorSistemasMotivoConsulta = Value
                End Set
            End Property


        End Class
#End Region

#Region "SubClase Antecedentes Perinatales"
        Public Class cAntecedentesPerinatales


            Private _dtDatosAntecedentes As DataTable
            Public Property DatosAntecedentes() As DataTable
                Get
                    Return _dtDatosAntecedentes
                End Get
                Set(ByVal Value As DataTable)
                    _dtDatosAntecedentes = Value
                End Set
            End Property

            Private _blnTieneInformacion As Boolean = False
            Public Property TieneInformacion() As Boolean
                Get
                    Return _blnTieneInformacion
                End Get
                Set(ByVal Value As Boolean)
                    _blnTieneInformacion = Value
                End Set
            End Property

        End Class
#End Region 'GVA

#Region "SubClase Desarrollo Psicomotor"
        Public Class cDesarrolloPsicomotor

            Private _dtDesarrolloPsicomotor As DataTable
            Public Property DatosDesarrolloPsicomotor() As DataTable
                Get
                    Return _dtDesarrolloPsicomotor
                End Get
                Set(ByVal Value As DataTable)
                    _dtDesarrolloPsicomotor = Value
                End Set
            End Property


            Private _blnTieneInformacion As Boolean = False
            Public Property TieneInformacion() As Boolean
                Get
                    Return _blnTieneInformacion
                End Get
                Set(ByVal Value As Boolean)
                    _blnTieneInformacion = Value
                End Set
            End Property

        End Class
#End Region 'GVA

#Region "SubClase Antecedentes Patologicos"
        Public Class cAntecedentesPatologicos

            Private _dtDatosAntecedentes As DataTable
            Public Property DatosAntecedentes() As DataTable
                Get
                    Return _dtDatosAntecedentes
                End Get
                Set(ByVal Value As DataTable)
                    _dtDatosAntecedentes = Value
                End Set
            End Property

            Private _intUltimaSecuenciaAntecedentes As Integer = 0
            Public Property UltimaSecuenciaAntecedentes() As Integer
                Get
                    Return _intUltimaSecuenciaAntecedentes
                End Get
                Set(ByVal Value As Integer)
                    _intUltimaSecuenciaAntecedentes = Value
                End Set
            End Property
        End Class
#End Region

#Region "SubClase Antecedentes Ginecologicos"
        Public Class cAntecedentesGinecologicos

            Private _dtDatosAntecedentes As DataTable
            Public Property DatosAntecedentes() As DataTable
                Get
                    Return _dtDatosAntecedentes
                End Get
                Set(ByVal Value As DataTable)
                    _dtDatosAntecedentes = Value
                End Set
            End Property

            Private _blnTieneInformacion As Boolean = False
            Public Property TieneInformacion() As Boolean
                Get
                    Return _blnTieneInformacion
                End Get
                Set(ByVal Value As Boolean)
                    _blnTieneInformacion = Value
                End Set
            End Property
        End Class
#End Region

#Region "SubClase Antecedentes Quirurgicos"
        Public Class cAntecedentesQuirurgicos

            Private _dtDatosAntecedentes As DataTable
            Public Property DatosAntecedentes() As DataTable
                Get
                    Return _dtDatosAntecedentes
                End Get
                Set(ByVal Value As DataTable)
                    _dtDatosAntecedentes = Value
                End Set
            End Property
        End Class
#End Region

#Region "SubClase Antecedentes Transfusionales"
        Public Class cAntecedentesTransfusionales

            Private _dtDatosAntecedentes As DataTable
            Public Property DatosAntecedentes() As DataTable
                Get
                    Return _dtDatosAntecedentes
                End Get
                Set(ByVal Value As DataTable)
                    _dtDatosAntecedentes = Value
                End Set
            End Property
        End Class
#End Region

#Region "SubClase Antecedentes Farmacologicos"
        Public Class cAntecedentesFarmacologicos

            Private _dtDatosAntecedentes As DataTable
            Public Property DatosAntecedentes() As DataTable
                Get
                    Return _dtDatosAntecedentes
                End Get
                Set(ByVal Value As DataTable)
                    _dtDatosAntecedentes = Value
                End Set
            End Property
        End Class
#End Region
        'cdqf
#Region "SubClase Antecedentes Traumatologicos"
        Public Class cAntecedentesTrauma

            Private _dtDatosAntecedentes As DataTable
            Public Property DatosAntecedentes() As DataTable
                Get
                    Return _dtDatosAntecedentes
                End Get
                Set(ByVal Value As DataTable)
                    _dtDatosAntecedentes = Value
                End Set
            End Property
        End Class
#End Region
        'cdqf

#Region "SubClase Antecedentes Alergicos"
        Public Class cAntecedentesAlergicos

            Private _dtDatosAntecedentes As DataTable
            Public Property DatosAntecedentes() As DataTable
                Get
                    Return _dtDatosAntecedentes
                End Get
                Set(ByVal Value As DataTable)
                    _dtDatosAntecedentes = Value
                End Set
            End Property
        End Class
#End Region

#Region "SubClase Antecedentes Toxicos"
        Public Class cAntecedentesToxicos

            Private _dtDatosAntecedentes As DataTable
            Public Property DatosAntecedentes() As DataTable
                Get
                    Return _dtDatosAntecedentes
                End Get
                Set(ByVal Value As DataTable)
                    _dtDatosAntecedentes = Value
                End Set
            End Property
        End Class
#End Region

#Region "SubClase Antecedentes Familiares"
        Public Class cAntecedentesFamiliares

            Private _dtDatosAntecedentes As DataTable
            Public Property DatosAntecedentes() As DataTable
                Get
                    Return _dtDatosAntecedentes
                End Get
                Set(ByVal Value As DataTable)
                    _dtDatosAntecedentes = Value
                End Set
            End Property
        End Class
#End Region

#Region "SubClase Antecedentes Vacunas"
        Public Class cVacunas

            Private _dtDatosAntecedentes As DataTable
            Public Property DatosAntecedentes() As DataTable
                Get
                    Return _dtDatosAntecedentes
                End Get
                Set(ByVal Value As DataTable)
                    _dtDatosAntecedentes = Value
                End Set
            End Property

            Private _dtDatosOtrasVacunas As DataTable
            Public Property DatosOtrasVacunas() As DataTable
                Get
                    Return _dtDatosOtrasVacunas
                End Get
                Set(ByVal Value As DataTable)
                    _dtDatosOtrasVacunas = Value
                End Set
            End Property
        End Class
#End Region

#Region "SubClase Examen Fisico"
        Public Class cExamenFisico

            Private _intTensionArterialSistole As Nullable(Of Integer) = Nothing

            Public Property TensionArterialSistole() As Nullable(Of Integer)
                Get
                    Return _intTensionArterialSistole
                End Get
                Set(ByVal Value As Nullable(Of Integer))
                    _intTensionArterialSistole = Value
                End Set
            End Property

            Private _intTensionArterialDiastole As Nullable(Of Integer) = Nothing
            Public Property TensionArterialDiastole() As Nullable(Of Integer)
                Get
                    Return _intTensionArterialDiastole
                End Get
                Set(ByVal Value As Nullable(Of Integer))
                    _intTensionArterialDiastole = Value
                End Set
            End Property

            Private _intFrecuenciaRespiratoria As Integer = 0
            Public Property FrecuenciaRespiratoria() As Integer
                Get
                    Return _intFrecuenciaRespiratoria
                End Get
                Set(ByVal Value As Integer)
                    _intFrecuenciaRespiratoria = Value
                End Set
            End Property

            Private _intFrecuenciaCardiaca As Integer = 0
            Public Property FrecuenciaCardiaca() As Integer
                Get
                    Return _intFrecuenciaCardiaca
                End Get
                Set(ByVal Value As Integer)
                    _intFrecuenciaCardiaca = Value
                End Set
            End Property

            Private _sngTemperatura As Single = 0.0
            Public Property Temperatura() As Single
                Get
                    Return _sngTemperatura
                End Get
                Set(ByVal Value As Single)
                    _sngTemperatura = Value
                End Set
            End Property


            Private _sngPeso As Nullable(Of Single) = Nothing
            Public Property Peso() As Nullable(Of Single)
                Get
                    Return _sngPeso
                End Get
                Set(ByVal Value As Nullable(Of Single))
                    _sngPeso = Value
                End Set
            End Property






            Private _sngTalla As Nullable(Of Single) = Nothing
            Public Property Talla() As Nullable(Of Single)
                Get
                    Return _sngTalla
                End Get
                Set(ByVal Value As Nullable(Of Single))
                    _sngTalla = Value
                End Set
            End Property

            Private _sngIndiceDeMasaCorporal As Single = 0.0
            Public Property IndiceDeMasaCorporal() As Single
                Get
                    Return _sngIndiceDeMasaCorporal
                End Get
                Set(ByVal Value As Single)
                    _sngIndiceDeMasaCorporal = Value
                End Set
            End Property

            Private _sngPerimetroCefalico As Nullable(Of Single) = Nothing
            Public Property PerimetroCefalico() As Nullable(Of Single)
                Get
                    Return _sngPerimetroCefalico
                End Get
                Set(ByVal Value As Nullable(Of Single))
                    _sngPerimetroCefalico = Value
                End Set
            End Property

            Private _sngPerimetroAbdominal As Nullable(Of Single) = Nothing
            Public Property PerimetroAbdominal() As Nullable(Of Single)
                Get
                    Return _sngPerimetroAbdominal
                End Get
                Set(ByVal Value As Nullable(Of Single))
                    _sngPerimetroAbdominal = Value
                End Set
            End Property

            Private _strCodigoEstadoDeConciencia As String = ""
            Public Property CodigoEstadoDeConciencia() As String
                Get
                    Return _strCodigoEstadoDeConciencia
                End Get
                Set(ByVal Value As String)
                    _strCodigoEstadoDeConciencia = Value
                End Set
            End Property

            Private _strDescripcionEstadoDeConciencia As String = ""
            Public Property StrDescripcionEstadoDeConciencia() As String
                Get
                    Return _strDescripcionEstadoDeConciencia
                End Get
                Set(ByVal Value As String)
                    _strDescripcionEstadoDeConciencia = Value
                End Set
            End Property

            Private _intGlasgow As Integer = 0
            Public Property Glasgow() As Integer
                Get
                    Return _intGlasgow
                End Get
                Set(ByVal Value As Integer)
                    _intGlasgow = Value
                End Set
            End Property

            Private _strEmbriaguez As String = ""
            Public Property Embriaguez() As String
                Get
                    Return _strEmbriaguez
                End Get
                Set(ByVal Value As String)
                    _strEmbriaguez = Value
                End Set
            End Property

            Private _dtHallazgos As DataTable
            Public Property Hallazgos() As DataTable
                Get
                    Return _dtHallazgos
                End Get
                Set(ByVal Value As DataTable)
                    _dtHallazgos = Value
                End Set
            End Property

            Private _strEstadoGeneral As String = ""
            Public Property EstadoGeneral() As String
                Get
                    Return _strEstadoGeneral
                End Get
                Set(ByVal Value As String)
                    _strEstadoGeneral = Value
                End Set
            End Property

            Private _strConfidencial As String = "N"
            Public Property Confidencial() As String
                Get
                    Return _strConfidencial
                End Get
                Set(ByVal Value As String)
                    _strConfidencial = Value
                End Set
            End Property

            Private _strEAnaloga_dolor As String
            Public Property EAnaloga_dolor() As String
                Get
                    Return _strEAnaloga_dolor
                End Get
                Set(ByVal Value As String)
                    _strEAnaloga_dolor = Value
                End Set
            End Property

            Private _sngsatoxi As Single = 0.0
            Public Property SaturacionOxigeno() As Single
                Get
                    Return _sngsatoxi
                End Get
                Set(ByVal Value As Single)
                    _sngsatoxi = Value
                End Set
            End Property



            Private _blnTieneInformacion As Boolean = False
            Public Property TieneInformacion() As Boolean
                Get
                    Return _blnTieneInformacion
                End Get
                Set(ByVal Value As Boolean)
                    _blnTieneInformacion = Value
                End Set
            End Property

        End Class
#End Region

#Region "SubClase Impresion Diagnostica"
        Public Class cImpresionDiagnostica
            Private _dtDatosDiagnosticos As DataTable
            Public Property DatosDiagnosticos() As DataTable
                Get
                    Return _dtDatosDiagnosticos
                End Get
                Set(ByVal Value As DataTable)
                    _dtDatosDiagnosticos = Value
                End Set
            End Property

            Private _strCodigoCausaExterna As String = ""
            Public Property CodigoCausaExterna() As String
                Get
                    Return _strCodigoCausaExterna
                End Get
                Set(ByVal Value As String)
                    _strCodigoCausaExterna = Value
                End Set
            End Property

            Private _blnHabilitarCausaExterna As Boolean = True
            Public Property HabilitarCausaExterna() As Boolean
                Get
                    Return _blnHabilitarCausaExterna
                End Get
                Set(ByVal Value As Boolean)
                    _blnHabilitarCausaExterna = Value
                End Set
            End Property

            Private _strDescripcionCausaExterna As String = ""
            Public Property DescripcionCausaExterna() As String
                Get
                    Return _strDescripcionCausaExterna
                End Get
                Set(ByVal Value As String)
                    _strDescripcionCausaExterna = Value
                End Set
            End Property

            Private _strCodigoCondicionUsuaria As String = ""
            Public Property CodigoCondicionUsuaria() As String
                Get
                    Return _strCodigoCondicionUsuaria
                End Get
                Set(ByVal Value As String)
                    _strCodigoCondicionUsuaria = Value
                End Set
            End Property

            Private _blnHabilitarCondicionUsuaria As Boolean = True
            Public Property HabilitarCondicionUsuaria() As Boolean
                Get
                    Return _blnHabilitarCondicionUsuaria
                End Get
                Set(ByVal Value As Boolean)
                    _blnHabilitarCondicionUsuaria = Value
                End Set
            End Property

            Private _blnHabilitarPlanManejo As Boolean = True
            Public Property HabilitarPlanManejo() As Boolean
                Get
                    Return _blnHabilitarPlanManejo
                End Get
                Set(ByVal Value As Boolean)
                    _blnHabilitarPlanManejo = Value
                End Set
            End Property

            Private _blnHabilitarReaccionAdversa As Boolean = True
            Public Property HabilitarReaccionAdversa() As Boolean
                Get
                    Return _blnHabilitarReaccionAdversa
                End Get
                Set(ByVal Value As Boolean)
                    _blnHabilitarReaccionAdversa = Value
                End Set
            End Property

            Private _strSospechaATEP As String = ""
            Public Property SospechaATEP() As String
                Get
                    Return _strSospechaATEP
                End Get
                Set(ByVal Value As String)
                    _strSospechaATEP = Value
                End Set
            End Property

            Private _blnHabilitarSospechaATEP As Boolean = True
            Public Property HabilitarSospechaATEP() As Boolean
                Get
                    Return _blnHabilitarSospechaATEP
                End Get
                Set(ByVal Value As Boolean)
                    _blnHabilitarSospechaATEP = Value
                End Set
            End Property

            Private _strAmpliacionDeLaOcupacion As String = ""
            Public Property AmpliacionDeLaOcupacion() As String
                Get
                    Return _strAmpliacionDeLaOcupacion
                End Get
                Set(ByVal Value As String)
                    _strAmpliacionDeLaOcupacion = Value
                End Set
            End Property

            Private _blnHabilitarAmpliacionOcupacion As Boolean = False
            Public Property HabilitarAmpliacionOcupacion() As Boolean
                Get
                    Return _blnHabilitarAmpliacionOcupacion
                End Get
                Set(ByVal Value As Boolean)
                    _blnHabilitarAmpliacionOcupacion = Value
                End Set
            End Property

            Private _intTiempoDeAntiguedadEnLaOcupacion As Integer = 0
            Public Property TiempoDeAntiguedadEnLaOcupacion() As Integer
                Get
                    Return _intTiempoDeAntiguedadEnLaOcupacion
                End Get
                Set(ByVal Value As Integer)
                    _intTiempoDeAntiguedadEnLaOcupacion = Value
                End Set
            End Property

            Private _blnHabilitarTiempoAntiguedadOcupacion As Boolean = False
            Public Property HabilitarTiempoAntiguedadOcupacion() As Boolean
                Get
                    Return _blnHabilitarTiempoAntiguedadOcupacion
                End Get
                Set(ByVal Value As Boolean)
                    _blnHabilitarTiempoAntiguedadOcupacion = Value
                End Set
            End Property

            Private _strCodigoAntiguedadEnLaOcupacion As String = ""
            Public Property CodigoAntiguedadEnLaOcupacion() As String
                Get
                    Return _strCodigoAntiguedadEnLaOcupacion
                End Get
                Set(ByVal Value As String)
                    _strCodigoAntiguedadEnLaOcupacion = Value
                End Set
            End Property

            Private _blnHabilitarAntiguedadOcupacion As Boolean = False
            Public Property HabilitarAntiguedadOcupacion() As Boolean
                Get
                    Return _blnHabilitarAntiguedadOcupacion
                End Get
                Set(ByVal Value As Boolean)
                    _blnHabilitarAntiguedadOcupacion = Value
                End Set
            End Property

            Private _strDescripcionAntiguedadEnLaOcupacion As String = ""
            Public Property DescripcionAntiguedadEnLaOcupacion() As String
                Get
                    Return _strDescripcionAntiguedadEnLaOcupacion
                End Get
                Set(ByVal Value As String)
                    _strDescripcionAntiguedadEnLaOcupacion = Value
                End Set
            End Property

            Private _blnTieneDiagnosticoPrincipal As Boolean = False
            Public Property TieneDiagnosticoPrincipal() As Boolean
                Get
                    Return _blnTieneDiagnosticoPrincipal
                End Get
                Set(ByVal Value As Boolean)
                    _blnTieneDiagnosticoPrincipal = Value
                End Set
            End Property

            Private _strSospechaRAM As String = ""
            Public Property SospechaRAM() As String
                Get
                    Return _strSospechaRAM
                End Get
                Set(ByVal Value As String)
                    _strSospechaRAM = Value
                End Set
            End Property

            Private _blnHabilitarSospechaRAM As Boolean = True
            Public Property HabilitarSospechaRAM() As Boolean
                Get
                    Return _blnHabilitarSospechaRAM
                End Get
                Set(ByVal Value As Boolean)
                    _blnHabilitarSospechaRAM = Value
                End Set
            End Property

            Private _strReaccionAdversa As String = ""
            Public Property ReaccionAdversa() As String
                Get
                    Return _strReaccionAdversa
                End Get
                Set(ByVal Value As String)
                    _strReaccionAdversa = Value
                End Set
            End Property

            Private _strDescripcionPlandeManejo As String = ""
            Public Property DescripcionPlandeManejo() As String
                Get
                    Return _strDescripcionPlandeManejo
                End Get
                Set(ByVal Value As String)
                    _strDescripcionPlandeManejo = Value
                End Set
            End Property
            'cdqf inclusion req ER_OSI 570
            Private _strDescripcionAnalisis As String = ""
            Public Property DescripcionAnalisis() As String
                Get
                    Return _strDescripcionAnalisis
                End Get
                Set(ByVal Value As String)
                    _strDescripcionAnalisis = Value
                End Set
            End Property
            Private _strExplicaPlanManejo As String = ""
            Public Property ExplicaPlanManejo() As String
                Get
                    Return _strExplicaPlanManejo
                End Get
                Set(ByVal Value As String)
                    _strExplicaPlanManejo = Value
                End Set
            End Property
            'cdqf
            Private _blnPermitirEliminarRegistro As Boolean = False
            Public ReadOnly Property PermitirEliminarRegistro() As Boolean
                Get
                    _blnPermitirEliminarRegistro = _blnHabilitarCausaExterna And _blnHabilitarCondicionUsuaria And _
                    _blnHabilitarSospechaATEP And _blnHabilitarSospechaRAM
                    Return _blnPermitirEliminarRegistro
                End Get
            End Property
        End Class
#End Region

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free unmanaged resources when explicitly called
                End If

                ' TODO: free shared unmanaged resources
                _Instancia = Nothing
            End If
            Me.disposedValue = True


        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

#Region "Limpiar Datos Objeto"

        Public Sub Limpiar()
            Me.StrDatoPendienteModificar = ""
            Me.TieneRegistros = False

            With Me.MotivoDeConsulta
                .InformacionSuministradaPor = ""
                .HabilitarInformacionSuministradaPor = True
                .MotivoDeConsulta = ""
                .HabilitarMotivoDeConsulta = True
                .EnfermedadActual = ""
                .HabilitarEnfermedadActual = True
                .RevisionPorSistemasMotivoConsulta = Nothing
            End With

            With Me.AntecedentesPerinatales
                .DatosAntecedentes = Nothing
                .TieneInformacion = False
            End With

            With Me.DesarrolloPsicomotor
                .DatosDesarrolloPsicomotor = Nothing
                .TieneInformacion = False
            End With

            With Me.AntecedentesPatologicos
                .DatosAntecedentes = Nothing
                .UltimaSecuenciaAntecedentes = 0
            End With

            With Me.AntecedentesGinecologicos
                .DatosAntecedentes = Nothing
                .TieneInformacion = False
            End With

            With Me.AntecedentesQuirurgicos
                .DatosAntecedentes = Nothing
            End With

            With Me.AntecedentesFarmacologicos
                .DatosAntecedentes = Nothing
            End With

            With Me.AntecedentesAlergicos
                .DatosAntecedentes = Nothing
            End With

            With Me.AntecedentesToxicos
                .DatosAntecedentes = Nothing
            End With

            With Me.AntecedentesFamiliares
                .DatosAntecedentes = Nothing
            End With

            With Me.Vacunas
                .DatosAntecedentes = Nothing
                .DatosOtrasVacunas = Nothing
            End With


            With Me.ExamenFisico
                .TensionArterialSistole = 0
                .TensionArterialDiastole = 0
                .FrecuenciaRespiratoria = 0
                .FrecuenciaCardiaca = 0
                .Temperatura = 0.0
                .Peso = 0.0
                .SaturacionOxigeno = 0.0
                .Talla = 0.0
                .IndiceDeMasaCorporal = 0.0
                .PerimetroCefalico = 0.0
                .PerimetroAbdominal = 0.0
                .CodigoEstadoDeConciencia = ""
                .StrDescripcionEstadoDeConciencia = ""
                .Glasgow = 0
                .Embriaguez = ""
                .Hallazgos = Nothing
                .EstadoGeneral = ""
                .Confidencial = "N"
                .TieneInformacion = False
            End With


            With Me.ImpresionDiagnostica
                .DatosDiagnosticos = Nothing
                .CodigoCausaExterna = ""
                .HabilitarCausaExterna = True
                .DescripcionCausaExterna = ""
                .CodigoCondicionUsuaria = ""
                .HabilitarCondicionUsuaria = True
                .HabilitarPlanManejo = True
                .HabilitarReaccionAdversa = True
                .SospechaATEP = ""
                .HabilitarSospechaATEP = True
                .AmpliacionDeLaOcupacion = ""
                .HabilitarAmpliacionOcupacion = False
                .TiempoDeAntiguedadEnLaOcupacion = 0
                .HabilitarTiempoAntiguedadOcupacion = False
                .CodigoAntiguedadEnLaOcupacion = ""
                .HabilitarAntiguedadOcupacion = False
                .DescripcionAntiguedadEnLaOcupacion = ""
                .TieneDiagnosticoPrincipal = False
                .SospechaRAM = ""
                .HabilitarSospechaRAM = True
                .ReaccionAdversa = ""
                .DescripcionPlandeManejo = ""
            End With
        End Sub
#End Region

    End Class
#End Region


End Namespace