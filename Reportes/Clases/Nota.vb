Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Nota
        Inherits GPMDataReport

        Private _fecha As String
        Public Property Fecha() As String
            Get
                Return _fecha
            End Get
            Set(ByVal Value As String)
                _fecha = Value
            End Set
        End Property

        Private _hora As String
        Public Property Hora() As String
            Get
                Return _hora
            End Get
            Set(ByVal Value As String)
                _hora = Value
            End Set
        End Property

        Private _descripcion As String
        Public Property Descripcion() As String
            Get
                Return _descripcion
            End Get
            Set(ByVal Value As String)
                _descripcion = Value
            End Set
        End Property

        Private _nombreMedico As String
        Public Property NombreMedico() As String
            Get
                Return _nombreMedico
            End Get
            Set(ByVal value As String)
                _nombreMedico = value
            End Set
        End Property

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal strFecha As String, ByVal strHora As String, ByVal strDescripcion As String)
            Dim fecha As Date

            fecha = strFecha
            _fecha = Format(fecha, "dd/MM/yyyy")
            fecha = strHora
            _hora = Format(fecha, "HH:mm")
            _descripcion = strDescripcion
        End Sub

        Public Shared Function consultarNotas(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
                   ByVal strCod_sucur As String, ByVal strTip_admision As String,
                   ByVal iano_adm As Long, ByVal lnum_adm As Double) As List(Of Nota)

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim objNota As Nota
            Dim drDatos As IDataReader
            Dim listaNotas As New List(Of Nota)

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)

            '' ''command = db.GetStoredProcCommandWrapper("pa_Reportes_HCNotas")

            '' ''With command
            '' ''    .AddInParameter("strcod_pre_sgs", DbType.String, strcod_pre_sgs)
            '' ''    .AddInParameter("strCod_sucur", DbType.String, strCod_sucur)
            '' ''    .AddInParameter("strTip_admision", DbType.String, strTip_admision)
            '' ''    .AddInParameter("iano_adm", DbType.Int16, iano_adm)
            '' ''    .AddInParameter("lnum_adm", DbType.Double, lnum_adm)
            '' ''End With

            '' ''drDatos = db.ExecuteReader(command)
            Dim _objDatosGenerales As objGeneral.Generales
            Dim OrigenBD As String
            _objDatosGenerales = objGeneral.Generales.Instancia

            OrigenBD = _objDatosGenerales.OrigenAdm


            gpmDataObj.setSQLSentence("Exec " + OrigenBD + "pa_Reportes_HCNotas " + "'" +
                                      strcod_pre_sgs + "'" + "," + "'" + strCod_sucur + "'" +
                                      "," + "'" + strTip_admision + "'" + "," + "'" + CStr(iano_adm) + "'" + "," + "'" +
                                      CStr(lnum_adm) + "'" + "", CommandType.Text)


            'gpmDataObj.setSQLSentence("pa_Reportes_HCNotas", CommandType.StoredProcedure)
            If gpmDataObj.ParametersCollection.Count > 0 Then
                gpmDataObj.ParametersCollection.Clear()
            End If

            gpmDataObj.addInputParameter("strcod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            gpmDataObj.addInputParameter("strCod_sucur", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("strTip_admision", SqlDbType.VarChar, strTip_admision)
            gpmDataObj.addInputParameter("iano_adm", SqlDbType.Int, iano_adm)
            gpmDataObj.addInputParameter("lnum_adm", SqlDbType.Decimal, lnum_adm)

            drDatos = gpmDataObj.ExecRdr()
            If Not drDatos Is Nothing Then
                While drDatos.Read()
                    objNota = New Nota(drDatos("fecha_nota").ToString, drDatos("hora_nota").ToString, drDatos("nota").ToString)
                    objNota.NombreMedico = drDatos("NombreMedico").ToString
                    listaNotas.Add(objNota)
                End While
            End If

            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If
            '' ''command.Command.Connection.Close()
            '' ''command.Command.Connection.Dispose()

            Return listaNotas

        End Function
    End Class
End Namespace

