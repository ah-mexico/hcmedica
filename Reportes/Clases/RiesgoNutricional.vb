Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports System.Collections.Generic
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    Public Class RiesgoNutricional
        Inherits GPMDataReport

        'Private _cod_pre_sgs As String
        'Private _cod_sucur As String
        'Private _tip_admision As String
        'Private _ano_adm As Integer
        'Private _num_adm As Decimal
        'Private _tip_doc As String
        'Private _num_doc As String
        Private _id_perdida_apetito As Integer
        Private _PerdidaApetito As String
        Private _id_perdida_peso As Integer
        Private _PerdidaPeso As String
        Private _id_nivel_perdida_peso As Integer
        Private _desc_nivel_perdida_peso As String
        Private _puntaje_riesgo As Integer
        'Private _fecha_creacion As DateTime
        'Private _login As String
        'Private _obs As String

        'Public Property cod_pre_sgs() As String
        '    Get
        '        Return _cod_pre_sgs
        '    End Get
        '    Set(ByVal Value As String)
        '        _cod_pre_sgs = Value
        '    End Set
        'End Property

        'Public Property cod_sucur() As String
        '    Get
        '        Return _cod_sucur
        '    End Get
        '    Set(ByVal Value As String)
        '        _cod_sucur = Value
        '    End Set
        'End Property

        'Public Property tip_admision() As String
        '    Get
        '        Return _tip_admision
        '    End Get
        '    Set(ByVal Value As String)
        '        _tip_admision = Value
        '    End Set
        'End Property

        'Public Property ano_adm() As Integer
        '    Get
        '        Return _ano_adm
        '    End Get
        '    Set(ByVal Value As Integer)
        '        _ano_adm = Value
        '    End Set
        'End Property

        'Public Property num_adm() As Decimal
        '    Get
        '        Return _num_adm
        '    End Get
        '    Set(ByVal Value As Decimal)
        '        _num_adm = Value
        '    End Set
        'End Property

        'Public Property tip_doc() As String
        '    Get
        '        Return _tip_doc
        '    End Get
        '    Set(ByVal Value As String)
        '        _tip_doc = Value
        '    End Set
        'End Property

        'Public Property num_doc() As String
        '    Get
        '        Return _num_doc
        '    End Get
        '    Set(ByVal Value As String)
        '        _num_doc = Value
        '    End Set
        'End Property

        Public Property id_perdida_apetito() As Integer
            Get
                Return _id_perdida_apetito
            End Get
            Set(ByVal Value As Integer)
                _id_perdida_apetito = Value
            End Set
        End Property

        Public Property PerdidaApetito() As String
            Get
                Return _PerdidaApetito
            End Get
            Set(ByVal Value As String)
                _PerdidaApetito = Value
            End Set
        End Property


        Public Property id_perdida_peso() As Integer
            Get
                Return _id_perdida_peso
            End Get
            Set(ByVal Value As Integer)
                _id_perdida_peso = Value
            End Set
        End Property

        Public Property PerdidaPeso() As String
            Get
                Return _PerdidaPeso
            End Get
            Set(ByVal Value As String)
                _PerdidaPeso = Value
            End Set
        End Property

        Public Property id_nivel_perdida_peso() As Integer
            Get
                Return _id_nivel_perdida_peso
            End Get
            Set(ByVal Value As Integer)
                _id_nivel_perdida_peso = Value
            End Set
        End Property

        Public Property desc_nivel_perdida_peso() As String
            Get
                Return _desc_nivel_perdida_peso
            End Get
            Set(ByVal Value As String)
                _desc_nivel_perdida_peso = Value
            End Set
        End Property

        Public Property puntaje_riesgo() As Integer
            Get
                Return _puntaje_riesgo
            End Get
            Set(ByVal Value As Integer)
                _puntaje_riesgo = Value
            End Set
        End Property



        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal PerdidaApetito As String, ByVal PerdidaPeso As String, ByVal Puntaje As String)
            _PerdidaApetito = PerdidaApetito
            _PerdidaPeso = PerdidaPeso
            _puntaje_riesgo = Puntaje
        End Sub

        Public Function consultarRiesgoNutricional(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String, _
                   ByVal Cod_sucur As String, ByVal Tip_admision As String, _
                   ByVal ano_adm As Long, ByVal num_adm As Double) As RiesgoNutricional

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 14/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim objRiesgoNutricional As RiesgoNutricional
            Dim drDatos As IDataReader
            Dim listaRiesgoNutricionales As New List(Of RiesgoNutricional)

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)

            '' ''command = db.GetStoredProcCommandWrapper("pa_Reportes_HCRiesgoNutricionalXsistemas")

            '' ''With command
            '' ''    .AddInParameter("strcod_pre_sgs", DbType.String, strcod_pre_sgs)
            '' ''    .AddInParameter("strCod_sucur", DbType.String, strCod_sucur)
            '' ''    .AddInParameter("strTip_admision", DbType.String, strTip_admision)
            '' ''    .AddInParameter("iano_adm", DbType.Int16, iano_adm)
            '' ''    .AddInParameter("lnum_adm", DbType.Double, lnum_adm)
            '' ''End With

            '' ''drDatos = db.ExecuteReader(command)

            gpmDataObj.setSQLSentence("HCL_LSTRNUTRICION", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("strcod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            gpmDataObj.addInputParameter("strCod_sucur", SqlDbType.VarChar, Cod_sucur)
            gpmDataObj.addInputParameter("strTip_admision", SqlDbType.VarChar, Tip_admision)
            gpmDataObj.addInputParameter("iano_adm", SqlDbType.Int, ano_adm)
            gpmDataObj.addInputParameter("lnum_adm", SqlDbType.Decimal, num_adm)

            drDatos = gpmDataObj.ExecRdr()
            'Inicializar(drDatos)

            While drDatos.Read()
                objRiesgoNutricional = New RiesgoNutricional(drDatos("PerdidaApetito").ToString, drDatos("PerdidaPeso").ToString, drDatos("puntaje_riesgo").ToString)
                'listaRiesgoNutricionales.Add(objRiesgoNutricional)
            End While

            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If
            '' ''command.Command.Connection.Close()
            '' ''command.Command.Connection.Dispose()

            Return objRiesgoNutricional
        End Function

        Public Sub Inicializar(ByVal drDatos As DbDataReader)
            While drDatos.Read()
                _PerdidaApetito = drDatos("PerdidaApetito").ToString
                _PerdidaPeso = drDatos("PerdidaPeso").ToString
                _puntaje_riesgo = drDatos("puntaje_riesgo").ToString
            End While

        End Sub

        'Public Function crearListaRiesgoNutricionalSistema(ByVal dtRiesgoNutricional As DataTable) As List(Of RiesgoNutricional)
        '    Dim listaRiesgoNutricionales As New List(Of RiesgoNutricional)
        '    Dim objRiesgoNutricional As RiesgoNutricional
        '    Dim i As Integer

        '    If dtRiesgoNutricional Is Nothing Then
        '        Return listaRiesgoNutricionales
        '    End If

        '    For i = 0 To dtRiesgoNutricional.Rows.Count - 1
        '        objRiesgoNutricional = New RiesgoNutricional(dtRiesgoNutricional.Rows(i).Item("PerdidaApetito").ToString(), _
        '                                   dtRiesgoNutricional.Rows(i).Item("PerdidaPeso").ToString(), _
        '                                   dtRiesgoNutricional.Rows(i).Item("puntaje_riesgo").ToString())

        '        listaRiesgoNutricionales.Add(objRiesgoNutricional)
        '    Next

        '    Return listaRiesgoNutricionales
        'End Function

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class
End Namespace

