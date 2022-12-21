Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion

Namespace Sophia.HistoriaClinica.Reportes
    Public Class ExamenFisico
        Inherits GPMDataReport

        Private Const ALERTA As String = "1"
        Private Const RESPONDEAVOZ As String = "2"
        Private Const RESPONDEADOLOR As String = "3"
        Private Const INCONSCIENTE As String = "4"

#Region "Propiedades"
        Private _peso As String
        Public Property Peso() As String
            Get
                Return _peso
            End Get
            Set(ByVal Value As String)
                _peso = Value
            End Set
        End Property

        Private _talla As String
        Public Property Talla() As String
            Get
                Return _talla
            End Get
            Set(ByVal Value As String)
                _talla = Value
            End Set
        End Property

        Private _iMC As String
        Public Property IMC() As String
            Get
                Return _iMC
            End Get
            Set(ByVal Value As String)
                _iMC = Value
            End Set
        End Property

        Private _perimetroCefalico As String
        Public Property PerimetroCefalico() As String
            Get
                Return _perimetroCefalico
            End Get
            Set(ByVal Value As String)
                _perimetroCefalico = Value
            End Set
        End Property

        Private _perimetroAbdominal As String
        Public Property PerimetroAbdominal() As String
            Get
                Return _perimetroAbdominal
            End Get
            Set(ByVal Value As String)
                _perimetroAbdominal = Value
            End Set
        End Property

        Private _sistole As String
        Public Property Sistole() As String
            Get
                Return _sistole
            End Get
            Set(ByVal Value As String)
                _sistole = Value
            End Set
        End Property

        Private _diastole As String
        Public Property Diastole() As String
            Get
                Return _diastole
            End Get
            Set(ByVal Value As String)
                _diastole = Value
            End Set
        End Property

        Private _Tension As String
        Public Property Tension() As String
            Get
                Return _Tension
            End Get
            Set(ByVal Value As String)
                _Tension = Value
            End Set
        End Property

        Private _temperatura As String
        Public Property Temperatura() As String
            Get
                Return _temperatura
            End Get
            Set(ByVal Value As String)
                _temperatura = Value
            End Set
        End Property

        Private _frecuenciaCardica As String
        Public Property FrecuenciaCardica() As String
            Get
                Return _frecuenciaCardica
            End Get
            Set(ByVal Value As String)
                _frecuenciaCardica = Value
            End Set
        End Property

        Private _frecuenciaRespiratoria As String
        Public Property FrecuenciaRespiratoria() As String
            Get
                Return _frecuenciaRespiratoria
            End Get
            Set(ByVal Value As String)
                _frecuenciaRespiratoria = Value
            End Set
        End Property

        Private _estadoConciencia As String
        Public Property EstadoConciencia() As String
            Get
                Return _estadoConciencia
            End Get
            Set(ByVal Value As String)
                _estadoConciencia = Value
            End Set
        End Property

        Private _glasgow As String
        Public Property Glasgow() As String
            Get
                Return _glasgow
            End Get
            Set(ByVal Value As String)
                _glasgow = Value
            End Set
        End Property

        Private _embriagez As String
        Public Property Embriagez() As String
            Get
                Return _embriagez
            End Get
            Set(ByVal Value As String)
                _embriagez = Value
            End Set
        End Property
        Private _SaturacionOxi As String ''Claudia Garay Cambios Acreditacion. Diciembre 10 de 2010
        Public Property SaturacionOxi() As String
            Get
                Return _SaturacionOxi
            End Get
            Set(ByVal Value As String)
                _SaturacionOxi = Value
            End Set
        End Property

        Private _EAnaloga_dolor As String ''Martovar Cambios version 2.8.0. 2014-08-19
        Public Property EAnaloga_dolor() As String
            Get
                Return _EAnaloga_dolor
            End Get
            Set(ByVal Value As String)
                _EAnaloga_dolor = Value
            End Set
        End Property

        Private _observaciones As String
        Public Property Observaciones() As String
            Get
                Return _observaciones
            End Get
            Set(ByVal Value As String)
                _observaciones = Value
            End Set
        End Property

        Private _isVisible As Boolean
        Public Property IsVisible() As Boolean
            Get
                Return _isVisible
            End Get
            Set(ByVal Value As Boolean)
                _isVisible = Value
            End Set
        End Property
#End Region

        Public Sub New()
            MyBase.New()
            _isVisible = False
        End Sub

        Public Sub New(ByVal peso As String, ByVal talla As String, ByVal strImc As String, _
        ByVal perimetros As String, ByVal sistole As String, ByVal diastole As String, ByVal Tension As String, _
        ByVal temperatura As String, ByVal frecCardiaca As String, ByVal frecRespiratoria As String, _
        ByVal alerta As String, ByVal glasgow As String, ByVal strEmbriaguez As String, ByVal strSaturaOxi As String, ByVal strEAnaloga_dolor As String, ByVal obs As String)

            _peso = peso
            _talla = talla
            _iMC = strImc
            _perimetroCefalico = perimetros
            _sistole = sistole
            _diastole = diastole
            _Tension = Tension
            _temperatura = temperatura
            _frecuenciaCardica = frecCardiaca
            _frecuenciaRespiratoria = frecRespiratoria
            _estadoConciencia = alerta
            _glasgow = glasgow
            _embriagez = strEmbriaguez
            _observaciones = obs
            _SaturacionOxi = strSaturaOxi ''Claudia Garay Acreditacion
            _EAnaloga_dolor = strEAnaloga_dolor

        End Sub

        Public Sub consultarExamenFisico(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, _
                   ByVal strCod_sucur As String, ByVal strTip_admision As String, _
                   ByVal iano_adm As Long, ByVal lnum_adm As Double, ByVal strLogin As String)

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim drDatos As IDataReader

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)

            '' ''command = db.GetStoredProcCommandWrapper("pa_Reportes_ExamenFisico")

            '' ''With command
            '' ''    .AddInParameter("strcod_pre_sgs", DbType.String, strcod_pre_sgs)
            '' ''    .AddInParameter("strCod_sucur", DbType.String, strCod_sucur)
            '' ''    .AddInParameter("strTip_admision", DbType.String, strTip_admision)
            '' ''    .AddInParameter("iano_adm", DbType.Int16, iano_adm)
            '' ''    .AddInParameter("lnum_adm", DbType.Double, lnum_adm)
            '' ''    .AddInParameter("strLogin", DbType.String, strLogin)
            '' ''End With

            '' ''drDatos = db.ExecuteReader(command)
            gpmDataObj.setSQLSentence("HC_RPT_EXAMENFISICO", CommandType.StoredProcedure)
            gpmDataObj.ClearParameters()
            gpmDataObj.addInputParameter("COD_PRE_SGS", SqlDbType.VarChar, strcod_pre_sgs)
            gpmDataObj.addInputParameter("COD_SUCUR", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("TIP_ADMISION", SqlDbType.VarChar, strTip_admision)
            gpmDataObj.addInputParameter("ANO_ADM", SqlDbType.Int, iano_adm)
            gpmDataObj.addInputParameter("NUM_ADM", SqlDbType.Decimal, lnum_adm)

            drDatos = gpmDataObj.ExecRdr()

            inicializar(drDatos)
            '' ''command.Command.Connection.Close()
            '' ''command.Command.Connection.Dispose()


        End Sub

        Public Sub inicializar(ByVal drDatos As IDataReader)

            Dim dato As Double

            While drDatos.Read()
                _peso = drDatos("PESO").ToString()

                'If drDatos("peso").ToString = "" Then
                '    _peso = ""
                'Else
                '    dato = CDbl(drDatos("PESO").ToString)
                '    _peso = Format(dato, "0.##")
                'End If
                _talla = drDatos("TALLA").ToString
                _iMC = drDatos("IMC").ToString
                _perimetroCefalico = drDatos("P_CEFALICO").ToString
                'If drDatos("P_CEFALICO").ToString = "" Then
                '    _perimetroCefalico = ""
                'Else
                '    dato = CDbl(drDatos("P_CEFALICO").ToString)
                '    _perimetroCefalico = Math.Round(dato)
                'End If

                _perimetroAbdominal = drDatos("P_ABDOMINAL").ToString
                _sistole = drDatos("TA_SIST").ToString
                _diastole = drDatos("TA_DIAS").ToString
                _Tension = drDatos("TENSION_ARTERIAL").ToString
                _temperatura = drDatos("TEMPERATURA").ToString
                _frecuenciaCardica = drDatos("FRE_CARDIACA").ToString
                _frecuenciaRespiratoria = drDatos("FRE_RESPIRA").ToString
                _estadoConciencia = drDatos("ALERTA").ToString

                _glasgow = drDatos("GLASGOW").ToString
                _embriagez = drDatos("EMBRIAGUEZ").ToString
                _SaturacionOxi = drDatos("SATOXI").ToString
                _observaciones = drDatos("OBS").ToString
                If drDatos("EANALOGA_DOLOR").ToString = "" Then
                    _EAnaloga_dolor = ""
                Else
                    _EAnaloga_dolor = drDatos("EANALOGA_DOLOR").ToString
                End If


            End While

        End Sub
        Public Sub inicializar(ByVal dtDatos As DataTable)

            For Each EA As DataRow In dtDatos.Rows
                _peso = EA("PESO").ToString()

                'If drDatos("peso").ToString = "" Then
                '    _peso = ""
                'Else
                '    dato = CDbl(drDatos("PESO").ToString)
                '    _peso = Format(dato, "0.##")
                'End If
                _talla = EA("TALLA").ToString
                _iMC = EA("IMC").ToString
                _perimetroCefalico = EA("P_CEFALICO").ToString
                'If drDatos("P_CEFALICO").ToString = "" Then
                '    _perimetroCefalico = ""
                'Else
                '    dato = CDbl(drDatos("P_CEFALICO").ToString)
                '    _perimetroCefalico = Math.Round(dato)
                'End If

                _perimetroAbdominal = EA("P_ABDOMINAL").ToString
                _sistole = EA("TA_SIST").ToString
                _diastole = EA("TA_DIAS").ToString
                '_Tension = EA("TENSION_ARTERIAL").ToString
                _temperatura = EA("TEMPERATURA").ToString
                _frecuenciaCardica = EA("FRE_CARDIACA").ToString
                _frecuenciaRespiratoria = EA("FRE_RESPIRA").ToString
                _estadoConciencia = EA("ALERTA").ToString

                _glasgow = EA("GLASGOW").ToString
                _embriagez = EA("EMBRIAGUEZ").ToString
                _SaturacionOxi = EA("SATOXI").ToString
                _observaciones = EA("OBS").ToString
                If EA("EANALOGA_DOLOR").ToString = "" Then
                    _EAnaloga_dolor = ""
                Else
                    _EAnaloga_dolor = EA("EANALOGA_DOLOR").ToString
                End If
            Next

        End Sub

    End Class
End Namespace

