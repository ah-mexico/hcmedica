Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Antecedente
        Inherits GPMDataReport

        Private _codigo As String
        Private _observaciones As String
        Private _Antecedente As String
        Private _tipoDocumentoMedico As String
        Private _numeroDocumentoMedico As String
        Private _nombreMedico As String
        Private _Fecha As String

      
#Region "Propiedades"
        Public Property Codigo() As String
            Get
                Return _codigo
            End Get
            Set(ByVal value As String)
                _codigo = value
            End Set
        End Property
        Public Property Observaciones() As String
            Get
                Return _observaciones
            End Get
            Set(ByVal value As String)
                _observaciones = value
            End Set
        End Property
        Public Property TipoDocumentoMedico() As String
            Get
                Return _tipoDocumentoMedico
            End Get
            Set(ByVal Value As String)
                _tipoDocumentoMedico = Value
            End Set
        End Property
        Public Property NumeroDocumentoMedico() As String
            Get
                Return _numeroDocumentoMedico
            End Get
            Set(ByVal Value As String)
                _numeroDocumentoMedico = Value
            End Set
        End Property
        Public Property NombreMedico() As String
            Get
                Return _nombreMedico
            End Get
            Set(ByVal Value As String)
                _nombreMedico = Value
            End Set
        End Property

        Public Property Fecha() As String
            Get
                Return _Fecha
            End Get
            Set(ByVal Value As String)
                _Fecha = Value
            End Set
        End Property

        Public Property Antecedente() As String
            Get
                Return _Antecedente
            End Get
            Set(ByVal value As String)
                _Antecedente = value
            End Set
        End Property


#End Region

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal strCodigo As String, ByVal strObs As String) ', ByVal sAntecedente As String)

            _codigo = strCodigo
            _observaciones = strObs
            '_Antecedente = sAntecedente
        End Sub

        Public Function consultarAntecedentes(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, _
                   ByVal strCod_sucur As String, ByVal strTipDoc As String, _
                   ByVal strNumDoc As String, ByVal strLogin As String, _
                   ByVal fechaHistoria As String, ByVal strTip_admision As String, ByVal lano_adm As String, _
                   ByVal dnum_adm As String, Optional ByVal fec_ini As String = "", _
                   Optional ByVal fec_fin As String = "") As List(Of Antecedente)

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim antAntecedente As Antecedente
            Dim drDatos As IDataReader
            Dim listaAntecedente As New List(Of Antecedente)

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)

            '' ''command = db.GetStoredProcCommandWrapper("pa_Reportes_AntecedentesOtros")

            '' ''With command
            '' ''    .AddInParameter("strTipDoc", DbType.String, strTipDoc)
            '' ''    .AddInParameter("strNumDoc", DbType.String, strNumDoc)
            '' ''    .AddInParameter("strLogin", DbType.String, strLogin)
            '' ''    .AddInParameter("fechaHistoria", DbType.String, fechaHistoria)
            '' ''End With

            '' ''drDatos = db.ExecuteReader(command)
            gpmDataObj.setSQLSentence("HC_RPT_ANTECEDENTESOTROS", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("TIPDOC", SqlDbType.VarChar, strTipDoc)
            gpmDataObj.addInputParameter("NUMDOC", SqlDbType.VarChar, strNumDoc)
            If fec_fin <> "" Or fec_fin <> "" Then
                gpmDataObj.addInputParameter("FEC_INI", SqlDbType.DateTime, fec_ini)
                gpmDataObj.addInputParameter("FEC_FIN", SqlDbType.DateTime, fec_fin)
            Else
                gpmDataObj.addInputParameter("FEC_INI", SqlDbType.DateTime, Nothing)
                gpmDataObj.addInputParameter("FEC_FIN", SqlDbType.DateTime, Nothing)
            End If

            drDatos = gpmDataObj.ExecRdr()

            While drDatos.Read()
                antAntecedente = New Antecedente("", drDatos("ANTECEDENTE").ToString)
                antAntecedente.Antecedente = drDatos("ANTECEDENTE").ToString
                antAntecedente.NombreMedico = drDatos("PROFESIONAL").ToString
                antAntecedente.Fecha = drDatos("FECHA").ToString
                listaAntecedente.Add(antAntecedente)

            End While


            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If
            '' ''command.Command.Connection.Close()
            '' ''command.Command.Connection.Dispose()

            Return listaAntecedente
        End Function


    End Class
End Namespace

