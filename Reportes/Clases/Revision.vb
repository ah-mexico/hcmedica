Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports System.Collections.Generic

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Revision
        Inherits GPMDataReport

        Private _sistema As String
        Private _normal As String
        Private _observaciones As String
        Private _ObservacionSistema As String
        'Private _RiesgoNutricional As RiesgoNutricional

        Public Property Sistema() As String
            Get
                Return _sistema
            End Get
            Set(ByVal Value As String)
                _sistema = Value
            End Set
        End Property


        Public Property Normal() As String
            Get
                Return _normal
            End Get
            Set(ByVal Value As String)
                _normal = Value
            End Set
        End Property


        Public Property Observaciones() As String
            Get
                Return _observaciones
            End Get
            Set(ByVal Value As String)
                _observaciones = Value
            End Set
        End Property

        Public Property ObservacionSistema() As String
            Get
                Return _ObservacionSistema
            End Get
            Set(ByVal Value As String)
                _ObservacionSistema = Value
            End Set
        End Property

        'Public Property RiesgoNutricional() As RiesgoNutricional
        '    Get
        '        Return _RiesgoNutricional
        '    End Get
        '    Set(ByVal Value As RiesgoNutricional)
        '        _RiesgoNutricional = Value
        '    End Set
        'End Property


        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal strSistema As String, ByVal strNormal As String, ByVal strObs As String, ByVal strObservacionSistema As String)
            _sistema = strSistema
            _normal = strNormal
            _observaciones = strObs
            _ObservacionSistema = strObservacionSistema
        End Sub

        Public Function consultarRevision(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, _
                   ByVal strCod_sucur As String, ByVal strTip_admision As String, _
                   ByVal iano_adm As Long, ByVal lnum_adm As Double) As List(Of Revision)

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 14/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim objRevision As Revision
            Dim drDatos As IDataReader
            Dim listaRevisiones As New List(Of Revision)

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)

            '' ''command = db.GetStoredProcCommandWrapper("pa_Reportes_HCRevisionXsistemas")

            '' ''With command
            '' ''    .AddInParameter("strcod_pre_sgs", DbType.String, strcod_pre_sgs)
            '' ''    .AddInParameter("strCod_sucur", DbType.String, strCod_sucur)
            '' ''    .AddInParameter("strTip_admision", DbType.String, strTip_admision)
            '' ''    .AddInParameter("iano_adm", DbType.Int16, iano_adm)
            '' ''    .AddInParameter("lnum_adm", DbType.Double, lnum_adm)
            '' ''End With

            '' ''drDatos = db.ExecuteReader(command)

            gpmDataObj.setSQLSentence("pa_Reportes_HCRevisionXsistemas", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("strcod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            gpmDataObj.addInputParameter("strCod_sucur", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("strTip_admision", SqlDbType.VarChar, strTip_admision)
            gpmDataObj.addInputParameter("iano_adm", SqlDbType.Int, iano_adm)
            gpmDataObj.addInputParameter("lnum_adm", SqlDbType.Decimal, lnum_adm)

            drDatos = gpmDataObj.ExecRdr()

            While drDatos.Read()
                objRevision = New Revision(drDatos("descripcion").ToString, drDatos("valor").ToString, drDatos("obs").ToString, drDatos("ObservacionSistema").ToString)
                listaRevisiones.Add(objRevision)
            End While

            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If
            '' ''command.Command.Connection.Close()
            '' ''command.Command.Connection.Dispose()

            Return listaRevisiones
        End Function

        Public Function consultarRevisionXSistemasEA(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, _
                   ByVal strCod_sucur As String, ByVal strTip_admision As String, _
                   ByVal iano_adm As Long, ByVal lnum_adm As Double) As List(Of Revision)

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim objRevision As Revision
            Dim drDatos As IDataReader
            Dim listaRevisiones As New List(Of Revision)

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)

            '' ''command = db.GetStoredProcCommandWrapper("pa_Reportes_HCRevisionXsistemasEA")

            '' ''With command
            '' ''    .AddInParameter("strcod_pre_sgs", DbType.String, strcod_pre_sgs)
            '' ''    .AddInParameter("strCod_sucur", DbType.String, strCod_sucur)
            '' ''    .AddInParameter("strTip_admision", DbType.String, strTip_admision)
            '' ''    .AddInParameter("iano_adm", DbType.Int16, iano_adm)
            '' ''    .AddInParameter("lnum_adm", DbType.Double, lnum_adm)
            '' ''End With

            '' ''drDatos = db.ExecuteReader(command)

            gpmDataObj.setSQLSentence("HC_RPT_REVISIONXSISTEMASEA", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            gpmDataObj.addInputParameter("Cod_sucur", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("Tip_admision", SqlDbType.VarChar, strTip_admision)
            gpmDataObj.addInputParameter("ano_adm", SqlDbType.Int, iano_adm)
            gpmDataObj.addInputParameter("num_adm", SqlDbType.Decimal, lnum_adm)

            drDatos = gpmDataObj.ExecRdr()

            While drDatos.Read()
                objRevision = New Revision(drDatos("descripcion").ToString, drDatos("valor").ToString, drDatos("obs").ToString, drDatos("ObservacionSistema").ToString)
                listaRevisiones.Add(objRevision)
            End While

            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If
            '' ''command.Command.Connection.Close()
            '' ''command.Command.Connection.Dispose()

            Return listaRevisiones

        End Function

        Public Function crearListaRevisionSistema(ByVal dtRevision As DataTable) As List(Of Revision)
            Dim listaRevisiones As New List(Of Revision)
            Dim objRevision As Revision
            Dim i As Integer

            If dtRevision Is Nothing Then
                Return listaRevisiones
            End If

            For i = 0 To dtRevision.Rows.Count - 1
                objRevision = New Revision(dtRevision.Rows(i).Item("descripcion").ToString(), _
                                           dtRevision.Rows(i).Item("valor").ToString(), _
                                           dtRevision.Rows(i).Item("obs").ToString(), _
                                           dtRevision.Rows(i).Item("ObservacionSistema").ToString())

                listaRevisiones.Add(objRevision)
            Next

            Return listaRevisiones
        End Function

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class
End Namespace

